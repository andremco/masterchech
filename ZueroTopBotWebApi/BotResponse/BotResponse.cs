using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ZueroTopBotWebApi.BotResponse
{
    public class BotResponse
    {
        public static bool IsResponseNextTimeForTrouxa;

        public BotResponse()
        {
        }

        public static async void ResponseTrouxa(ITelegramBotClient botClient, Chat chat, string[] responseTrouxa)
        {
            foreach (var message in responseTrouxa)
            {
                await botClient.SendTextMessageAsync(
                        chatId: chat,
                        text: message
                );
            }
        }

        public static async void ResponseInfoOfVictim(ITelegramBotClient botClient, Chat chat)
        {
            await botClient.SendTextMessageAsync(
                        chatId: chat,
                        text: "Informe o nome do infortúnio: "
            );
        }

        public static async void ResponseNextTrouxa(ITelegramBotClient botClient, Chat chat, string badLanguage)
        {
            await botClient.SendTextMessageAsync(
                chatId: chat,
                text: "É " + badLanguage
            );
        }
    }
}
