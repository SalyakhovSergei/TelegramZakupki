using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using telegramnew;

namespace TelegramTestBot
{
    public class KeyboardButtonLeft
    {
        ListsOfItems listsOf = new ListsOfItems();

        public IReplyMarkup GetButtons2()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> {new KeyboardButton {Text = "Тампон-зонд с транспортной средой (БЕЛАЯ) Stuart, стер. в проб. п/п (шт)/Медика-Плюс" } },
                    new List<KeyboardButton> {new KeyboardButton {Text = "Тампон-зонд с транспортной средой (ЧЕРНАЯ) Amies, стер. в проб. п/п (шт)/Медика-Плюс" } },
                    new List<KeyboardButton> {new KeyboardButton {Text = "Тампон- зонд  (ПП + вискоза ) в пробирке без среды  стер.13 x 150 N 1800/уп. Китай G 1022" } },
                    new List<KeyboardButton> {new KeyboardButton {Text = "Тампон - зонд { П + вискоза ) стер. в пробирке  НР 5008 Китай" } },
                    new List<KeyboardButton> {new KeyboardButton {Text = "Тампон - зонд { П + вискоза ) стер. в пробирке  12 x 150 EXIM  Китай" } },
                    new List<KeyboardButton> {new KeyboardButton {Text = "Тубфер для взятия мазков о средой  Эймса 13x150 мм с голубой крышкой 50 шт /уп. Китай" } },
                    new List<KeyboardButton> {new KeyboardButton {Text = "Тубфер для взятия мазков о средой  Amies (c углем) 13x150 мм с голубой крышкой 50 шт/уп. Китай" } },
                    new List<KeyboardButton> {new KeyboardButton {Text = "Тест полоски Уриполиан-10 Н N  100" } },
                    new List<KeyboardButton> {new KeyboardButton {Text = "Зонд тампон для отбора биол.проб стерильный (пластик вискоза) 15 см стерильн.(без пробирки)" } },
                    new List<KeyboardButton> {new KeyboardButton {Text = "Зонд урогенитальный тип А" } }

                },
                ResizeKeyboard = true,
                OneTimeKeyboard = true
            };

            List <InlineKeyboardButton> list = new List<InlineKeyboardButton>();
            foreach (string s in listsOf.igla)
            {
                list.Add(InlineKeyboardButton.WithCallbackData(s));
            }
            return new InlineKeyboardMarkup(list);

        }

        public IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{ new KeyboardButton { Text = "/закупка основных средств"}},
                    new List<KeyboardButton>{ new KeyboardButton { Text = "/закупка расходных материалов"}},
                    new List<KeyboardButton>{ new KeyboardButton { Text = "/закупка тары"}},
                    new List<KeyboardButton>{ new KeyboardButton { Text = "/закупка ИТ девайсов"}},
                    new List<KeyboardButton>{ new KeyboardButton { Text = "/закупка прочего"}},

                },
                ResizeKeyboard = true
            };


        }




    }

   
}
