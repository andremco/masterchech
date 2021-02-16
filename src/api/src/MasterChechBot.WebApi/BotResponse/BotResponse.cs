using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MasterChechBotWebApi.BotResponse
{
    public class BotResponse
    {
        public static bool IsResponseTimeForTrouxa;

        public static async Task ResponseInfoOfVictim(ITelegramBotClient botClient, Chat chat)
        {
            await botClient.SendTextMessageAsync(
                        chatId: chat,
                        text: "Informe o nome do infortúnio: "
            );
        }

        public static async Task ResponseTrouxa(ITelegramBotClient botClient, Chat chat, string phrase)
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
                        text: response,
                        parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown
                );
        }
    }
}
