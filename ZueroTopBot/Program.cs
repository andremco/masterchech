using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ZueroTopBot
{
    public class Program
    {
        static IConfigurationRoot Configuration;
        static ILogger<Program> Logger;

        public static void Main(string[] args)
        {
            ConfigurationBuilder();

            Log();

            Logger.LogInformation($"Bot key: {Configuration["BotKey"]}");

            BuildWebHost(args).Run();
        }

        public static void ConfigurationBuilder()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
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
                .Build();
    }
}
