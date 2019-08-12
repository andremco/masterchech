using System.Linq;
using Core.Context;
using Core.Enum;
using Core.Messages;
using Core.Repositories;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace MasterChechBotWebApi.BotControl
{
    public static class BotControl
    {
        //static ITelegramBotClient BotClient;
        //static UnitOfWork UnitOfWork;

        //public static void ZueroTopBotTelegram()
        //{
        //    BotClient = new TelegramBotClient(Program.Configuration["BotKey"]);
        //    Context.ConnectionString = Program.Configuration["ConnectionStrings:DefaultConnection"];
        //    UnitOfWork = new UnitOfWork(new Context());

        //    var me = BotClient.GetMeAsync().Result;
        //    Program.Logger.LogInformation($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");

        //    BotClient.OnMessage += Bot_OnMessage;
        //    BotClient.StartReceiving();
        //}

        //static async void Bot_OnMessage(object sender, MessageEventArgs e)
        //{
        //    var text = e.Message.Text;

        //    if (text != null)
        //    {
        //        var business = new MessageOnShipBusiness(UnitOfWork);

        //        if (BotResponse.BotResponse.IsResponseTimeForTrouxa)
        //        {
        //            var phrase = business.GetPhrase();
        //            await BotResponse.BotResponse.ResponseTrouxa(BotClient, e.Message.Chat, phrase);
        //            BotResponse.BotResponse.IsResponseTimeForTrouxa = false;
        //            return;
        //        }

        //        if (business.IsCommandForBot(text))
        //        {
        //            Program.Logger.LogInformation($"Received a text message for user - {e.Message.From.Id} {e.Message.From.FirstName} {e.Message.From.LastName}.");

        //            var responseForUserEnum = business.CommandForBot(text);

        //            switch (responseForUserEnum)
        //            {
        //                case ResponseForUserEnum.Trouxa:
        //                    BotResponse.BotResponse.IsResponseTimeForTrouxa = true;
        //                    await BotResponse.BotResponse.ResponseInfoOfVictim(BotClient, e.Message.Chat);
        //                    break;

        //                case ResponseForUserEnum.CulinariaDoDia:
        //                    var culinariaDoDia = business.GetRandomRecipe();
        //                    if (!string.IsNullOrEmpty(culinariaDoDia))
        //                    {
        //                        await BotResponse.BotResponse.Response(BotClient, e.Message.Chat, culinariaDoDia);
        //                    }
        //                    break;
        //            }
        //        }
        //    }
        //}
    }
}
