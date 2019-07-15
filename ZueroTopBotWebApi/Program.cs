using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Enum;
using Core.Messages;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace ZueroTopBotWebApi
{
    public class Program
    {
        static IConfigurationRoot Configuration;
        static ITelegramBotClient BotClient;
        static ILogger<Program> Logger;

        public static void Main(string[] args)
        {
            ConfigurationBuilder();

            Log();

            ZueroTopBotTelegram();

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


        public static void ZueroTopBotTelegram(){
            BotClient = new TelegramBotClient(Configuration["BotKey"]);

            var me = BotClient.GetMeAsync().Result;
            Logger.LogInformation($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");

            BotClient.OnMessage += Bot_OnMessage;
            BotClient.StartReceiving();
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            var text = e.Message.Text;

            if (text != null)
            {
                var business = new MessageOnShipBusiness();

                if (business.IsCommandForBot(text))
                {
                    Logger.LogInformation($"Received a text message for user {e.Message.From}.");

                    var responseForUser = business.CommandForBot(text);

                    switch (responseForUser)
                    {
                        case ResponseForUser.Trouxa:

                            var responseTrouxa = business.ResponseTrouxa();

                            foreach (var message in responseTrouxa)
                            {
                                await BotClient.SendTextMessageAsync(
                                        chatId: e.Message.Chat,
                                        text: message
                                );
                            }
                            break;
                    }
                }
            }
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
