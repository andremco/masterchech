using System;
using System.Threading;
using System.Threading.Tasks;
using MasterChechBot.Core.Context;
using MasterChechBot.Core.Enum;
using MasterChechBot.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace MasterChechBotWebApi.HostedService
{
    public class BotTelegramHostedService : IHostedService
    {
        private readonly ILogger _logger;
        private readonly ITelegramBotClient _bot;
        private readonly MessageOnKitchen _messageOnShipBusiness;
        
        public BotTelegramHostedService(ILogger<BotTelegramHostedService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;

            using (var scope = serviceProvider.CreateScope())
            {
                var connectionString = Environment.GetEnvironmentVariable("ConnectionString");
                var context = new Context(connectionString);
                _bot = scope.ServiceProvider.GetService<ITelegramBotClient>();
                _messageOnShipBusiness = new MessageOnKitchen(context);
            }
        }

        private void BotTelegram()
        {
            var me = _bot.GetMeAsync().Result;
            _logger.LogInformation($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");

            _bot.OnMessage += Bot_OnMessage;
            _bot.StartReceiving();
        }

        public async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            var text = e.Message.Text;

            if (text != null)
            {
                if (_messageOnShipBusiness.IsCommandForBot(text))
                {
                    _logger.LogInformation($"Received a text message for user - {e.Message.From.Id} {e.Message.From.FirstName} {e.Message.From.LastName}.");

                    var responseForUserEnum = _messageOnShipBusiness.CommandForBot(text);

                    switch (responseForUserEnum)
                    {
                        case ResponseForUser.CulinariaDoDia:
                            var culinariaDoDia = _messageOnShipBusiness.GetRandomRecipe();
                            if (!string.IsNullOrEmpty(culinariaDoDia))
                            {
                                await BotResponse.BotResponse.Response(_bot, e.Message.Chat, culinariaDoDia);
                            }
                            break;
                    }
                }
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Consume Scoped Service Hosted Service is starting.");

            BotTelegram();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Consume Scoped Service Hosted Service is stopping.");

            return Task.CompletedTask;
        }
    }
}
