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
        private ITelegramBotClient _botClient;
        
      
        public void Initialize()
        {
            _botClient = new TelegramBotClient(BotCredentials.token);
        }

        public void Start()
        {
            _botClient.OnMessage += BotOnMessage;
            _botClient.StartReceiving();
        }

        public void Stop()
        {
            _botClient.StopReceiving();
        }

        private async void BotOnMessage(object sender, MessageEventArgs e)
        {
            KeyboardButtonLeft buttonLeft = new KeyboardButtonLeft();
            var msg = e.Message;
            
            await _botClient.SendTextMessageAsync(msg.Chat.Id, "Выберите товар: ", replyMarkup: buttonLeft.GetButtons2());
            
        }
    }
}
