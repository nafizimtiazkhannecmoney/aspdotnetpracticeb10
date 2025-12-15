using PaymentStatusDispatcher.Services;
using Serilog;

namespace PaymentStatusDispatcher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            // Fix: Use builder.Logging.AddSerilog instead of builder.Host.UseSerilog
            builder.Logging.AddSerilog((new LoggerConfiguration())
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .CreateLogger());

            // Load configs (From appsettings.json)
            builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            builder.Services.AddHttpClient();

            builder.Services.AddHostedService<Worker>();

            var host = builder.Build();
            host.Run();
        }
    }
}