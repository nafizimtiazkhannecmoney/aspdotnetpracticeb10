using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PaymentStatusDispatcher.Models;

namespace PaymentStatusDispatcher.Services
{
    public static class WesternUnionStatusRepository
    {
        public static async Task<List<PaymentStatusRow>> GetWesternUnionStatusesAsync(string connectionString, ILogger logger, CancellationToken stoppingToken)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                logger.LogError("Connection string 'EFTDatabase' was not found or is empty.");
                return new List<PaymentStatusRow>();
            }

            // Define the SQL query to retrieve Western Union payment statuses which have not been processed yet
            var sql = @"SELECT  
                            endToEndId = ExchgRefNo,
                            Status = (
                                CASE 
                                    WHEN ConfirmedDate IS NOT NULL THEN 'PAID'
                                    WHEN CnlAuthorisedDate IS NOT NULL THEN 'CANCEL'
                                END
                            ),
                            TTID
                        FROM ExchTTIssue e
                        WHERE RemitNoPrefix = 'WU'
                          AND (ConfirmedDate IS NOT NULL 
                               OR CnlAuthorisedDate IS NOT NULL)
                          AND NOT EXISTS (
                                SELECT 1
                                FROM WSRequestHistories w
                                WHERE w.TTID = e.TTID
                          );";


            // For testing purposes, temporarily removing the NOT EXISTS clause to reprocess all relevant TTIDs
            //var sql = @"SELECT   endToEndId = ExchgRefNo, Status = (CASE WHEN ConfirmedDate is not null then 'PAID' WHEN CnlAuthorisedDate is not null then 'CANCEL' END),
            //        TTID  FROM ExchTTIssue WHERE RemitNoPrefix = 'WU' and (ConfirmedDate is not null or CnlAuthorisedDate is not null)";

            var statuses = new List<PaymentStatusRow>();

            await using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync(stoppingToken);
            await using var command = new SqlCommand(sql, connection);
            await using var reader = await command.ExecuteReaderAsync(stoppingToken);

            while (await reader.ReadAsync(stoppingToken))
            {
                var row = new PaymentStatusRow
                {
                    EndToEndId = reader.IsDBNull(0) ? null : reader.GetString(0),
                    Status = reader.IsDBNull(1) ? null : reader.GetString(1),
                    TTID = reader.IsDBNull(2) ? null : reader.GetInt32(2)
                };

                if (string.IsNullOrWhiteSpace(row.EndToEndId) || string.IsNullOrWhiteSpace(row.Status))
                {
                    logger.LogWarning("Skipping row with missing EndToEndId or Status.");
                    continue;
                }

                statuses.Add(row);
            }

            return statuses;
        }

        public static async Task InsertIsSuccessfulOnResponseHistoryAsync(int ttid, string responseDetail, string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                                INSERT INTO [EFT].[dbo].[WSResponseHistories]
                                    (TTOf, TTID, ResponseDetail, ResponseTime, IsSuccessful)
                                VALUES
                                    (3, @TTID, @ResponseDetail, GETDATE(), 1);";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TTID", ttid);
                    cmd.Parameters.AddWithValue("@ResponseDetail", responseDetail);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public static async Task InsertOnRequestHistoryAsync(int ttid, string requestDetail, DateTime requestTime, string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                                INSERT INTO [EFT].[dbo].[WSRequestHistories]
                                    (TTOf, TTID, RequestDetail, RequestTime)
                                VALUES
                                    (3, @TTID, @RequestDetail, @RequestTime);";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TTID", ttid);
                    cmd.Parameters.AddWithValue("@RequestDetail", requestDetail);
                    cmd.Parameters.AddWithValue("@RequestTime", requestTime);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public static async Task InsertErrorHistoryAsync(int ttid, string errorDetail, DateTime errorTime, string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                                INSERT INTO [EFT].[dbo].[WSErrorHistories]
                                    (TTOf, TTID, ErrorDetail, ErrorTime)
                                VALUES
                                    (3, @TTID, @ErrorDetail, @ErrorTime);";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TTID", ttid);
                    cmd.Parameters.AddWithValue("@ErrorDetail", errorDetail);
                    cmd.Parameters.AddWithValue("@ErrorTime", errorTime);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }




    }
}
