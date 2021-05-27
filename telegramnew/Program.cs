using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using System.Data;
using System.Data.SqlClient;
using telegramnew;
using System.Linq;

namespace TelegramTestBot
{
    class Program
    {
        private static TelegramBotClient botclient;
        private static SqlConnection sql = new SqlConnection(BotCredentials.connectionstring);

        static void Main(string[] args)
        {
            botclient = new TelegramBotClient(BotCredentials.token);

            botclient.StartReceiving();

            botclient.OnMessage += BotOnMessage;

            Console.ReadLine();
            botclient.StopReceiving();
        }
        private static async void BotOnMessage(object sender, MessageEventArgs e)
        {
            KeyboardButtonLeft buttonLeft = new KeyboardButtonLeft();
            ListsOfItems listsOfItems = new ListsOfItems();
            var msg = e.Message;
                        
                if (listsOfItems.category.Contains(msg.Text))
                {
                    if (sql.State == ConnectionState.Closed)
                    {
                        sql.Open();
                        SqlCommand command = new SqlCommand($"INSERT INTO testTable (item, categ) values ('{msg.Text}', '{msg.Chat.Id}')", sql);
                        await command.ExecuteNonQueryAsync();
                        sql.Close();
                    }
                        
                    await botclient.SendTextMessageAsync(msg.Chat.Id, "Выберите товар: ", replyMarkup: buttonLeft.GetButtons2());
                }
                
                else if(listsOfItems.tampons.Contains(msg.Text))
                {                    
                        sql.Open();
                        SqlCommand command = new SqlCommand($"Update testTable Set qty = '{msg.Text}' where categ = '{msg.Chat.Id}'", sql);
                        await command.ExecuteNonQueryAsync();
                        sql.Close();
                  
                    await botclient.SendTextMessageAsync(msg.Chat.Id, "Введите количество: ");
                }
               else
                {
                    await botclient.SendTextMessageAsync(msg.Chat.Id, "Выберите категорию: ", replyMarkup: buttonLeft.GetButtons());
                }
               
            
        }

    

    }
}