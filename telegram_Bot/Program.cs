using Telegram.Bot;
using Telegram.Bot.Requests;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace telegram_Bot
{
    internal class Program
    {
        private static string token { get; set; } = "5523210316:AAEMz0pf5sLYCrm4Ej_YkwgB1c1XA9cqYf8";
        static void Main(string[] args)
        {
            var client = new TelegramBotClient(token);
            client.StartReceiving(updateHandler,Error);
           
            Console.ReadLine();
            
        }

       

        async static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }

        async static Task updateHandler(ITelegramBotClient telegramBotClient, Update update, CancellationToken arg3)
        {
            var message = update.Message;

            try{
                if ( message != null )
                {
 
                    await telegramBotClient.SendTextMessageAsync(message.Chat.Id, "Нажмите на кнопку:", replyMarkup: InlineKeyboard());
                    return;
                }
               
                    switch (update.Type)
                    {
                        case UpdateType.CallbackQuery:
                        var button = update.CallbackQuery.Data;
                        if (button == "A1-A2")
                        {
                            await telegramBotClient.AnswerCallbackQueryAsync(update.CallbackQuery.Id, $"Вы выбрали ={button}");
                            return;
                        }
                        else if (button == "B1-B2") 
                        {
                            await telegramBotClient.AnswerCallbackQueryAsync(update.CallbackQuery.Id, $"Вы выбрали ={button}");
                            return;
                        }
                        else if (button == "C1-C2") 
                            {
                                await telegramBotClient.AnswerCallbackQueryAsync(update.CallbackQuery.Id, $"Вы выбрали ={button}");
                                return;
                            }
                        else if (button == "Random")
                        {
                            await telegramBotClient.AnswerCallbackQueryAsync(update.CallbackQuery.Id, $"Вы выбрали ={button}");
                            return;
                        }
                        
                        break;

                      default:
                             break;
                    }
                 
                }
            
            catch(Exception ex)
            {
              if(message.Text=="/stop")
                    await telegramBotClient.SendTextMessageAsync(message.Chat.Id,ex.Message);
            }
        }

        private static IReplyMarkup? InlineKeyboard() => new InlineKeyboardMarkup(new[]
                    {
                               // first row
                               new []
                               {
                                   InlineKeyboardButton.WithCallbackData(textAndCallbackData:"A1-A2"),
                                   InlineKeyboardButton.WithCallbackData(textAndCallbackData:"B1-B2")
                               },
                               // second row
                               new []
                              {
                                   InlineKeyboardButton.WithCallbackData(textAndCallbackData:"C1-C2"),
                                   InlineKeyboardButton.WithCallbackData(textAndCallbackData:"Random"),

                              }
                          });
    }
       
    
}