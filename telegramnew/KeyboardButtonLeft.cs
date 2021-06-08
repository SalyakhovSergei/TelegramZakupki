using System.Collections.Generic;
using System.Linq;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramTestBot.Data;

namespace TelegramTestBot
{
    public static class KeyboardButtonLeft
    { 
        
        public const string CategoryName = "Категория";
        public const string ItemName = "Товары";
        public const string CreateOrderName = "Создать заказ";
        public const string ConfirmOrder = "Подтвердить заказ";
        
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
    }
}