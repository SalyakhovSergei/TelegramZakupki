﻿using System.Collections.Generic;
using System.Linq;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramTestBot.Data;

namespace TelegramTestBot
{
    public static class OrderCommands
    { 
        
        public const string CategoryName = "Категория - ";
        public const string ItemName = "Товар - ";
        public const string CreateOrderName = "Создать заказ";
        public const string ConfirmAddingItemToOrder = "Добавить товар в заказ";
        public const string ConfirmOrder = "Подтвердить заказ";
        public const string CompleteOrder = "Завершить заказ";
        
      public static IReplyMarkup GetCategoryButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = Products.ListOfProducts.Select(o => o.Category).Distinct()
                    .Select(o => new List<KeyboardButton>() {new KeyboardButton {Text = CategoryName + o}}).ToList(),
                ResizeKeyboard = true
            };
        }
        public static IReplyMarkup GetItemButtons(string category)
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = Products.ListOfProducts.Where(o => o.Category == category)
                    .Select(o => new List<KeyboardButton>() {new KeyboardButton {Text = ItemName + o.Name}}).ToList(),
                ResizeKeyboard = true
            };
        }
        public static IReplyMarkup CreateOrderButton()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new[] {new List<KeyboardButton>{new KeyboardButton {Text = CreateOrderName}}},
               
                ResizeKeyboard = true
            };
        }
        public static IReplyMarkup ConfirmAddingItemToOrderButton()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new[] {new List<KeyboardButton>{new KeyboardButton {Text = ConfirmAddingItemToOrder}}},
               
                ResizeKeyboard = true
            };
        }
        public static IReplyMarkup ConfirmOrderButton()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new[] {new List<KeyboardButton>{new KeyboardButton {Text = ConfirmOrder}}},
               
                ResizeKeyboard = true
            };
        }
        public static IReplyMarkup CompleteOrderButton()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new[] {new List<KeyboardButton>{new KeyboardButton {Text = CompleteOrder}}},
               
                ResizeKeyboard = true
            };
        }
    }
}