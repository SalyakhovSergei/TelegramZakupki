using System;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using TelegramTestBot.Data;
using TelegramTestBot.Models;
using TelegramTestBot.OrderInstructions;
using TelegramTestBot.Repositories;

namespace TelegramTestBot
{
    public class BotLogic: IBotLogic
    {
        private ITelegramBotClient _botClient;
        private static Chat telegramChat;
        private Order _userOrder;
       private OrdersProcessor _ordersProcessor;
        
        public void Initialize()
        {
            _botClient = new TelegramBotClient(BotCredentials.token);
            _ordersProcessor = new OrdersProcessor(new OrderRepository());
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
            var msg = e.Message;
            var msgText = msg.Text;
            
            if (msgText == "старт")
            {
                await _botClient.SendTextMessageAsync(msg.Chat.Id, "Сделайте заказ",
                    replyMarkup: OrderCommands.CreateOrderButton());
            }
            if (msgText ==OrderCommands.CreateOrderName)
            {
               _ordersProcessor.CreateNewOrder(msg.Chat.Id);
                await _botClient.SendTextMessageAsync(msg.Chat.Id, "Выберите категорию: ",
                    replyMarkup: OrderCommands.GetCategoryButtons());
                
            }
            
            if (msgText.StartsWith(OrderCommands.CategoryName))
            {
                await _botClient.SendTextMessageAsync(msg.Chat.Id, "Выберите товар: ",
                    replyMarkup: OrderCommands.GetItemButtons(msgText.Replace(OrderCommands.CategoryName, string.Empty)));
                
            }

            if (msgText.StartsWith(OrderCommands.ItemName))
            {
                _ordersProcessor.AppendItemToOrder(msg.Chat.Id, Products.ListOfProducts.FirstOrDefault(o => o.Name == msg.Text.Replace(OrderCommands.ItemName, string.Empty)).Id);
                
            }
            
            

        }
    
        
    }
}
