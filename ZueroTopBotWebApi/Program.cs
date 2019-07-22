using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ZueroTopBotWebApi
{
    public class Program
    {
        public static IConfigurationRoot Configuration;
        
        public static ILogger<Program> Logger;

        public static void Main(string[] args)
        {
            ConfigurationBuilder();

            Log();

            BotControl.BotControl.ZueroTopBotTelegram();

            BuildWebHost(args).Run();
        }

        public static IConfigurationRoot ConfigurationBuilder()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            return Configuration;
        }

        public static void Log()
        {
            var logFactory = new LoggerFactory()
                .AddConsole(LogLevel.Information)
                .AddDebug();

            Logger = logFactory.CreateLogger<Program>();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");
                })
                .Build();
    }
}
