using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Context;
using Core.Enum;
using Core.Messages;
using Core.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace MasterChechBotWebApi.HostedService
{
    public class BotTelegramHostedService : IHostedService
    {
        private IConfiguration _configuration;
        private readonly IServiceProvider _services;
        private readonly ILogger _logger;
        private readonly ITelegramBotClient _bot;
        private readonly UnitOfWork _uow;

        public BotTelegramHostedService(IConfiguration configuration, IServiceProvider services,
            ILogger<BotTelegramHostedService> logger)
        {
            _configuration = configuration;
            _services = services;
            _logger = logger;
            _bot = new TelegramBotClient(_configuration["BotKey"]);
            using (var scope = services.CreateScope())
            {
                var uow =
                    scope.ServiceProvider
                        .GetRequiredService<UnitOfWork>();
                _uow = uow;
            }
        }

        private void BotTelegram()
        {
            var me = _bot.GetMeAsync().Result;
            _logger.LogInformation($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");

            _bot.OnMessage += Bot_OnMessage;
            _bot.StartReceiving();
        }

        async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            var text = e.Message.Text;

            if (text != null)
            {
                var business = new MessageOnShipBusiness(_uow);

                if (BotResponse.BotResponse.IsResponseTimeForTrouxa)
                {
                    var phrase = business.GetPhrase();
                    await BotResponse.BotResponse.ResponseTrouxa(_bot, e.Message.Chat, phrase);
                    BotResponse.BotResponse.IsResponseTimeForTrouxa = false;
                    return;
                }

                if (business.IsCommandForBot(text))
                {
                    _logger.LogInformation($"Received a text message for user - {e.Message.From.Id} {e.Message.From.FirstName} {e.Message.From.LastName}.");

                    var responseForUserEnum = business.CommandForBot(text);

                    switch (responseForUserEnum)
                    {
                        case ResponseForUserEnum.Trouxa:
                            BotResponse.BotResponse.IsResponseTimeForTrouxa = true;
                            await BotResponse.BotResponse.ResponseInfoOfVictim(_bot, e.Message.Chat);
                            break;

                        case ResponseForUserEnum.CulinariaDoDia:
                            var culinariaDoDia = business.GetRandomRecipe();
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
