using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ZueroTopBotWebApi.BotResponse
{
    public class BotResponse
    {
        public static bool IsResponseNextTimeForTrouxa;

        public static async Task ResponseTrouxa(ITelegramBotClient botClient, Chat chat, string[] responseTrouxa)
        {
            foreach (var message in responseTrouxa)
            {
                await botClient.SendTextMessageAsync(
                        chatId: chat,
                        text: message
                );
            }
        }

        public static async Task ResponseInfoOfVictim(ITelegramBotClient botClient, Chat chat)
        {
            await botClient.SendTextMessageAsync(
                        chatId: chat,
                        text: "Informe o nome do infortúnio: "
            );
        }

        public static async Task ResponseNextTrouxa(ITelegramBotClient botClient, Chat chat, string phrase)
        {
            await botClient.SendTextMessageAsync(
                chatId: chat,
                text: "É " + phrase
            );
        }

        public static async Task Response(ITelegramBotClient botClient, Chat chat, string response)
        {
            await botClient.SendTextMessageAsync(
                        chatId: chat,
                        text: response
                );
        }
    }
}
