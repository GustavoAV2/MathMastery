using Microsoft.EntityFrameworkCore;
using HttpHost.Data;
using HttpHost;
using Serilog;
using Serilog.Events;

namespace HttpHost
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("API is running...");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var minimumLevel = LogEventLevel.Information;

                var settings = config.Build();
                var logLevel = settings["SERILOG_MINIMUM_LEVEL"];

                if (Enum.TryParse<LogEventLevel>(logLevel, true, out var level))
                    minimumLevel = level;

                Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Is(minimumLevel)
                                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                                .MinimumLevel.Override("System", LogEventLevel.Warning)
                                .Enrich.FromLogContext()
                                .CreateLogger();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            }).ConfigureServices(services =>
            {
                services.AddDbContext<UserDb>(opt => opt.UseInMemoryDatabase("MemoryDatabase"));
                services.AddDbContext<FriendDb>(opt => opt.UseInMemoryDatabase("MemoryDatabase"));
            });
    }
}