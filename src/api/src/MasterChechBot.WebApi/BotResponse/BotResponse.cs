using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MasterChechBotWebApi.BotResponse
{
    public class BotResponse
    {
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
