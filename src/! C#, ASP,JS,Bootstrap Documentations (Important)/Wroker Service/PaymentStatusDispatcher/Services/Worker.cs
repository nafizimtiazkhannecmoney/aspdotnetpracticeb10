using System.Data.SqlClient;
using System.Text;
using PaymentStatusDispatcher.Models;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using System.Xml.Linq;

namespace PaymentStatusDispatcher.Services
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public Worker(ILogger<Worker> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpClient = httpClientFactory.CreateClient();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    await ProcessWesternUnionStatusesAsync(stoppingToken);    // WU Function
                    await ProcessMoneygramStatusAsync(stoppingToken);         // MG Function
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error calling API");
                }

                // Delay 150 seconds
                await Task.Delay(150000, stoppingToken);
            }
        }

        private async Task ProcessWesternUnionStatusesAsync(CancellationToken stoppingToken)
        {
            try
            {
                // 1. Get connection string + endpoint URL
                var connectionString = _configuration.GetConnectionString("EFTDatabase");
                var url = _configuration["PaymentStatusEndpoint:WesternUnionUAT"];
                if (string.IsNullOrWhiteSpace(url))
                {
                    _logger.LogError("PaymentStatusEndpoint:WesternUnionUAT is not configured.");
                    return;
                }

                // Fetch statuses using the static method
                var statuses = await WesternUnionStatusRepository.GetWesternUnionStatusesAsync(connectionString, _logger, stoppingToken);

                var client = _httpClientFactory.CreateClient();

                foreach (var row in statuses)
                {
                    // Decide payload based on status
                    string code;
                    string msg;
                    if (row.Status.Equals("CANCEL", StringComparison.OrdinalIgnoreCase))
                    {
                        code = "4024";
                        msg = "Cancelled";
                    }
                    else if (row.Status.Equals("PAID", StringComparison.OrdinalIgnoreCase))
                    {
                        code = "4030";
                        msg = "Paid";
                    }
                    else
                    {
                        _logger.LogWarning("Unknown status {Status} for EndToEndId {EndToEndId}. Skipping.", row.Status, row.EndToEndId);
                        continue;
                    }
                    // For now, assume msgId = endToEndId
                    var msgId = row.EndToEndId;
                    // TODO: for now we can use "now"
                    var creationDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    DateTime RequestSendingTime = creationDateTime != null ? DateTime.Parse(creationDateTime) : DateTime.Now;
                    var payloadObject = new
                    {
                        request = new
                        {
                            header = new
                            {
                                msgId,
                                creationDateTime,
                                auth = new
                                {
                                    userName = "necUser",
                                    password = "necUser"
                                },
                                initiatingParty = new
                                {
                                    _id = "NEC",
                                    name = "NEC"
                                }
                            },
                            paymentInfo = new
                            {
                                identification = new
                                {
                                    endToEndId = row.EndToEndId
                                }
                            },
                            status = new
                            {
                                code,
                                subCode = "",
                                msg
                            }
                        }
                    };
                    var json = JsonSerializer.Serialize(payloadObject);
                    using var content = new StringContent(json, Encoding.UTF8, "application/json");
                    _logger.LogInformation(
                        "Sending {Status} notification to WesternUnionUAT for EndToEndId={EndToEndId} with code={Code}",
                        row.Status,
                        row.EndToEndId,
                        code);
                    using var response = await client.PostAsync(url, content, stoppingToken);
                    var responseBody = await response.Content.ReadAsStringAsync(stoppingToken);

                    if (response.IsSuccessStatusCode)
                    {
                        _logger.LogInformation(
                            "WU response OK for EndToEndId={EndToEndId}. StatusCode={StatusCode}, Body={Body}",
                            row.EndToEndId,
                            (int)response.StatusCode,
                            responseBody);

                        //  NEW CODE: DESERIALIZE AND CHECK SUBCODE
                        try
                        {
                            var apiResponse = JsonSerializer.Deserialize<ApiResponse>(responseBody);
                            if ((apiResponse?.status?.subCode == "0000") && (apiResponse?.status?.code == "200"))
                            {
                                _logger.LogInformation(
                                    "Western Union status update SUCCESS for EndToEndId={EndToEndId} with subCode={subCode} and code={code}",
                                    row.EndToEndId, apiResponse?.status?.subCode, apiResponse?.status?.code);

                                // CALL DATABASE INSERT FUNCTION on [WSResponseHistories] Table
                                await WesternUnionStatusRepository.InsertIsSuccessfulOnResponseHistoryAsync((int)row.TTID!, responseBody, connectionString);

                                // CALL DATABASE INSERT FUNCTION on [WSRequestHistories] Table
                                await WesternUnionStatusRepository.InsertOnRequestHistoryAsync((int)row.TTID!, json, RequestSendingTime, connectionString);
                            }

                            else if ((apiResponse?.status?.code == "400") 
                                || (apiResponse?.status?.code == "401") 
                                || (apiResponse?.status?.code == "403") 
                                || (apiResponse?.status?.code == "404") 
                                || (apiResponse?.status?.code == "500"))
                            {
                                _logger.LogWarning(
                                    "Western Union status update Error Occured for EndToEndId={EndToEndId}. Received error code={code}- Sending this To [WSErrorHistories] Table",
                                    row.EndToEndId, apiResponse?.status?.code);
                                await WesternUnionStatusRepository.InsertErrorHistoryAsync((int)row.TTID!, responseBody, DateTime.Now, connectionString);
                            }
                            else
                            {
                                _logger.LogWarning(
                                    " ELSE--Western Union status update FAILED for EndToEndId={EndToEndId}. Unexpected subCode={SubCode} and code={code}",
                                    row.EndToEndId,
                                    apiResponse?.status?.subCode ?? "null", apiResponse?.status?.code);
                            }


                        }
                        catch (Exception)
                        {

                            throw;
                        }

                    }
                    else
                    {
                        _logger.LogWarning(
                            "WU response FAILED for EndToEndId={EndToEndId}. StatusCode={StatusCode}, Body={Body}",
                            row.EndToEndId,
                            (int)response.StatusCode,
                            responseBody);
                    }
                    // Optional: small delay between calls if needed (rate limiting)
                    await Task.Delay(600, stoppingToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing Western Union statuses.");
            }
        }

        private async Task ProcessMoneygramStatusAsync(CancellationToken stoppingToken)
        {
            try
            {
                // 1. Get connection string + endpoint URL
                var connectionString = _configuration.GetConnectionString("EFTDatabase");
                // Fetch statuses using the static method
                var statuses = await MoneyGramStatusRepository.GetMoneyGramStatusesAsync(connectionString, _logger, stoppingToken);

                // Decide payload based on status -Decide reason code/message
                foreach (var row in statuses)
                {
                    string ReasonCode;
                    string ReasonMessage;

                    if (row.Status.Equals("CANCEL", StringComparison.OrdinalIgnoreCase))
                    {
                        ReasonCode = "1409";
                        ReasonMessage = "Other Rejected";
                    }
                    else if (row.Status.Equals("PAID", StringComparison.OrdinalIgnoreCase))
                    {
                        ReasonCode = "1505";
                        ReasonMessage = "Received - Assumed Deposited by Partner";
                    }
                    else if (row.Status.Equals("ISSUED", StringComparison.OrdinalIgnoreCase))
                    {
                        ReasonCode = "1504";
                        ReasonMessage = "Received - Confirmed Deposited/Delivered";
                    }
                    else
                    {
                        _logger.LogWarning("Unknown status {Status} for EndToEndId {EndToEndId}. Skipping.", row.Status, row.EndToEndId);
                        continue;
                    }

                    // 1 Get endpoint URL and headers from configuration
                    string endpoint = _configuration["MoneyGram:Endpoint"]!;
                    string soapAction = _configuration["MoneyGram:SoapAction"]!;
                    string authorization = _configuration["MoneyGram:Authorization"]!;
                    string mgiTransactionID = row.EndToEndId!;
                    string partnerTransactionID = row.TTID.ToString()!;
                    string partnerReasonCode = ReasonCode;
                    string partnerReasonMessage = ReasonMessage;
                    string xmlns_soapenv = _configuration["MoneyGram:soapenv"]!;
                    string xmlns_par = _configuration["MoneyGram:par"]!;

                    // 2 Building SOAP XML payload(hardcoded for testing)
                    string soapRequest = $@"<soapenv:Envelope xmlns:soapenv=""{xmlns_soapenv}"" 
                                              xmlns:par=""{xmlns_par}"">
                                            <soapenv:Header/>
                                            <soapenv:Body>
                                                <par:updateStatus>
                                                    <par:status>
                                                        <par:mgiTransactionID>{row.EndToEndId}</par:mgiTransactionID>
                                                        <par:partnerTransactionID>{row.TTID}</par:partnerTransactionID>
                                                        <par:partnerReasonCode>{ReasonCode}</par:partnerReasonCode>
                                                        <par:partnerReasonMessage>{ReasonMessage}</par:partnerReasonMessage>
                                                    </par:status>
                                                </par:updateStatus>
                                            </soapenv:Body>
                                            </soapenv:Envelope>";

                    // 3 Create HTTP request
                    using var request = new HttpRequestMessage(HttpMethod.Post, endpoint);

                    request.Content = new StringContent(
                        soapRequest,
                        Encoding.UTF8,
                        "application/xml");

                    // 4 Add Required Headers
                    request.Headers.Add("SOAPAction", soapAction);
                    request.Headers.Add("Authorization", authorization);
                    //request.Headers.Add("Accept-Encoding", "gzip,deflate");
                    request.Headers.Connection.Add("Keep-Alive");

                    HttpResponseMessage response;
                    string responseContent;

                    // Handling Error Responses - log and continue and send the response to ErrorHistory Table
                    try
                    {
                        // 5 Send request
                         response = await _httpClient.SendAsync(request, stoppingToken);

                        // 6 Read response
                         responseContent = await response.Content.ReadAsStringAsync(stoppingToken);
                    }
                    catch (TaskCanceledException ex)
                    {
                        _logger.LogError(
                            ex,
                            "MoneyGram NETWORK TIMEOUT | EndToEndId: {EndToEndId} | TTID: {TTID}",
                            row.EndToEndId,
                            row.TTID);
                        continue;
                    }
                    catch (HttpRequestException ex)
                    {
                        _logger.LogError(
                            ex,
                            "MoneyGram NETWORK ERROR | EndToEndId: {EndToEndId} | TTID: {TTID}",
                            row.EndToEndId,
                            row.TTID);
                        continue;
                    }

                    // 8. SOAP RESPONSE HANDLING


                    // 9 Log Response status and body
                    //_logger.LogInformation("MoneyGram Response Status: {StatusCode}", response.StatusCode);
                    //_logger.LogInformation("MoneyGram Response Body:\n{Response}", responseContent);

                    _logger.LogInformation(
                         "MoneyGram Response Received | EndToEndId: {EndToEndId} | TTID: {TTID} | HTTP Status: {StatusCode}",
                         row.EndToEndId,
                         row.TTID,
                         response.StatusCode);
                   // _logger.LogDebug("MoneyGram Response Body:\n{Response}", responseContent);
                    _logger.LogInformation("MoneyGram Response Body:\n{Response}", responseContent);

                    // 10. SUCCESS vs ERROR LOGIC (EXACT REQUIREMENT)
                    try
                    {
                        var xml = XDocument.Parse(responseContent);

                        //XNamespace soapenv = "http://schemas.xmlsoap.org/soap/envelope/";
                        //XNamespace par = "http://moneygram.com/service/PartnerConnectService";
                        XNamespace soapenv = xmlns_soapenv;
                        XNamespace par = xmlns_par;

                        var updateStatusResponse = xml
                            .Descendants(par + "updateStatusResponse")
                            .FirstOrDefault();

                        // SUCCESS  empty updateStatusResponse
                        if (updateStatusResponse != null && !updateStatusResponse.HasElements)
                        {
                            // Insert request
                            await MoneyGramStatusRepository.InsertWSRequestHistoryAsync(
                                (int)row.TTID!,
                                soapRequest,
                                DateTime.Now,
                                connectionString);

                            // Insert response
                            await MoneyGramStatusRepository.InsertWSResponseHistoryAsync(
                                (int)row.TTID!,
                                responseContent,
                                connectionString);

                            _logger.LogInformation(
                                "MoneyGram SUCCESS STORED | EndToEndId: {EndToEndId} | TTID: {TTID}",
                                row.EndToEndId,
                                row.TTID);
                        }
                        else
                        {
                            // FAILURE  anything other than empty response
                            await MoneyGramStatusRepository.InsertWSErrorHistoryAsync(
                                (int)row.TTID!,
                                responseContent,
                                DateTime.Now,
                                connectionString);

                            _logger.LogError(
                                "MoneyGram ERROR STORED | EndToEndId: {EndToEndId} | TTID: {TTID}",
                                row.EndToEndId,
                                row.TTID);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Invalid / non-XML response  treat as error
                        await MoneyGramStatusRepository.InsertWSErrorHistoryAsync(
                            (int)row.TTID!,
                                responseContent,
                                DateTime.Now,
                                connectionString);

                        _logger.LogError(
                            ex,
                            "MoneyGram INVALID RESPONSE STORED AS ERROR | EndToEndId: {EndToEndId} | TTID: {TTID}",
                            row.EndToEndId,
                            row.TTID);
                    }

                    await Task.Delay(600, stoppingToken);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while calling MoneyGram SOAP API");
            }
        }


    }
}
