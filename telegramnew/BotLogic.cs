using System;
using System.Collections.Generic;
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
        private OrderRepository _orderRepository;
        
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
            var msg = e.Message;
            var msgText = msg.Text;
            
            if (msgText == "старт")
            {
                await _botClient.SendTextMessageAsync(msg.Chat.Id, "Сделайте заказ",
                    replyMarkup: OrderCommands.CreateOrderButton());
            }
            if (msgText.StartsWith(OrderCommands.CreateOrderName))
            {
                _userOrder = new Order()
                {
                    Id = new Guid(),
                    UserId = msg.Chat.Id,
                    Items = new Dictionary<Guid, int>()
                };
                
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
                
                
                
            }
            
            //создать  заказ и добавить в базу данных
            _orderRepository.CreateOrder(_userOrder);
            
            //Найти элемент в массиве ListOfProducts и добавить в словарь
            var item = Products.ListOfProducts.Find(item => item.Name == msgText);
            _userOrder.Items.Add(item.Id, 1);

        }
        
        // public Order order = new Order
        // {
        //     Id = Guid.NewGuid(),
        //     UserId = telegramChat.Id,
        //     Items = new Dictionary<Guid, int>()
        // };
        // public void IncreaseQuantityOfItems(Guid productId)
        // {
        //     if (order.Items.ContainsKey(productId))
        //     {
        //         order.Items[productId]++;
        //     }
        //     else
        //     {
        //         order.Items[productId]= 1;
        //     }
        // }

    }
}
