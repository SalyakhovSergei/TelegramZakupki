using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using TelegramTestBot.Data;

namespace TelegramTestBot
{
    public class BotLogic
    {
        private ITelegramBotClient botClient;
        
      
        public void Initialize()
        {
            botClient = new TelegramBotClient(BotCredentials.token);
        }

        public void Start()
        {
            botClient.OnMessage += BotOnMessage;
            botClient.StartReceiving();
        }

        public void Stop()
        {
            botClient.StopReceiving();
        }

        private async void BotOnMessage(object sender, MessageEventArgs e)
        {
            KeyboardButtonLeft buttonLeft = new KeyboardButtonLeft();
            Products listsOfItems = new Products();
            var msg = e.Message;

            if (listsOfItems.Category.Contains(msg.Text))
            {
                if (sql.State == ConnectionState.Closed)
                {
                    
                }

                await botClient.SendTextMessageAsync(msg.Chat.Id, "Выберите товар: ", replyMarkup: buttonLeft.GetButtons2());
            }

            else if (listsOfItems.tampons.Contains(msg.Text))
            {
                

                await botClient.SendTextMessageAsync(msg.Chat.Id, "Введите количество: ");
            }
            else
            {
                await botClient.SendTextMessageAsync(msg.Chat.Id, "Выберите категорию: ", replyMarkup: buttonLeft.GetButtons());
            }
        }
    }
}
