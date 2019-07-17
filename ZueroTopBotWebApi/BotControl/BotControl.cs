using Core.Enum;
using Core.Messages;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace ZueroTopBotWebApi.BotControl
{
    public static class BotControl
    {
        static ITelegramBotClient BotClient;

        public static void ZueroTopBotTelegram()
        {
            BotClient = new TelegramBotClient(Program.Configuration["BotKey"]);

            var me = BotClient.GetMeAsync().Result;
            Program.Logger.LogInformation($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");

            BotClient.OnMessage += Bot_OnMessage;
            BotClient.StartReceiving();
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            var text = e.Message.Text;

            if (text != null)
            {
                var business = new MessageOnShipBusiness();

                if (BotResponse.BotResponse.IsResponseNextTimeForTrouxa)
                {
                    var phrase = business.GetPhrase();
                    await BotResponse.BotResponse.ResponseNextTrouxa(BotClient, e.Message.Chat, phrase);
                    BotResponse.BotResponse.IsResponseNextTimeForTrouxa = false;
                    return;
                }

                if (business.IsCommandForBot(text))
                {
                    Program.Logger.LogInformation($"Received a text message for user - {e.Message.From.Id} {e.Message.From.FirstName} {e.Message.From.LastName}.");

                    var responseForUserEnum = business.CommandForBot(text);

                    switch (responseForUserEnum)
                    {
                        case ResponseForUserEnum.GustavoTrouxa:
                            var responseTrouxa = business.ResponseTrouxa();
                            await BotResponse.BotResponse.ResponseTrouxa(BotClient, e.Message.Chat, responseTrouxa);
                            break;

                        case ResponseForUserEnum.ProximoTrouxa:
                            BotResponse.BotResponse.IsResponseNextTimeForTrouxa = true;
                            await BotResponse.BotResponse.ResponseInfoOfVictim(BotClient, e.Message.Chat);
                            break;
                    }
                }
            }
        }
    }
}
