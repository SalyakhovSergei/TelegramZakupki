﻿using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using TelegramTestBot.Models;

namespace TelegramTestBot
{
    public class BotLogic
    {
        private ITelegramBotClient _botClient;
        private static Chat telegramChat;
        private Order _userOrder;
        
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
            if (msgText.StartsWith(KeyboardButtonLeft.CreateOrderName))
            {
                _userOrder = new Order()
                {
                    Id = new Guid(),
                    UserId = msg.Chat.Id,
                    Items = new Dictionary<Guid, int>()
                };
                
                await _botClient.SendTextMessageAsync(msg.Chat.Id, "Выберите товар: ",
                    replyMarkup: KeyboardButtonLeft.GetCategoryButtons());
            }
            if (msgText.StartsWith(KeyboardButtonLeft.CategoryName))
            {
                await _botClient.SendTextMessageAsync(msg.Chat.Id, "Выберите товар: ",
                    replyMarkup: KeyboardButtonLeft.GetItemButtons(msgText.Replace(KeyboardButtonLeft.CategoryName, string.Empty)));
            }

            
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
