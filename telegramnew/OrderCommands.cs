using System.Collections.Generic;
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
        public const string ToCategoriesList = "К списку категорий";
        public const string ToMainScreen = "В начало";
        
      public static IReplyMarkup GetCategoryButtons()
      {
          var buttons = Products.ListOfProducts.Select(o => o.Category).Distinct()
              .Select(o => new List<KeyboardButton>() {new KeyboardButton {Text = CategoryName + o}}).ToList();
          buttons.Add(ToMainButtons());
            return new ReplyKeyboardMarkup
            {
                Keyboard = buttons,
                ResizeKeyboard = true
            };
        }
        public static IReplyMarkup GetItemButtons(string category)
        {
            var buttons = Products.ListOfProducts.Where(o => o.Category == category)
                .Select(o => new List<KeyboardButton>() {new KeyboardButton {Text = ItemName + o.Name}}).ToList();
            buttons.Add(ToCategoriesButton());
            return new ReplyKeyboardMarkup
            {
                Keyboard = buttons,
                ResizeKeyboard = true
            };
        }
        public static IReplyMarkup CreateOrderButton()
        {
            return new ReplyKeyboardMarkup
            {
                //кнопка создание заказа
                Keyboard = new[] {new List<KeyboardButton>{new KeyboardButton {Text = CreateOrderName}}},
               
                ResizeKeyboard = true
            };
        }
        public static IReplyMarkup ConfirmAddingItemToOrderButton()
        {
            return new ReplyKeyboardMarkup
            {
                //кнопка подтверждения добавления товара в заказ
                Keyboard = new[] {new List<KeyboardButton>{new KeyboardButton {Text = ConfirmAddingItemToOrder}}},
               
                ResizeKeyboard = true
            };
        }
        public static IReplyMarkup ConfirmOrderButton()
        {
            return new ReplyKeyboardMarkup
            {
                //кнопка подтверждения заказа
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

        private static List<KeyboardButton> ToCategoriesButton()
        {
            return new List<KeyboardButton>{new KeyboardButton {Text = ToCategoriesList}};
        }
        private static List<KeyboardButton> ToMainButtons()
        {
            return new List<KeyboardButton>{new KeyboardButton {Text = ToMainScreen}};
        }
    }
}