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

        public static void Main(string[] args)
        {


            var builder = new ConfigurationBuilder()                            .SetBasePath(Directory.GetCurrentDirectory())                            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            Console.WriteLine($"Bot key: {Configuration["BotKey"]}");

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(logging =>
                {
                    logging.AddConsole();
                })
                .Build();
    }
}
