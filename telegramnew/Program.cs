using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using System.Data;
using System.Data.SqlClient;
using TelegramTestBot;
using System.Linq;
using TelegramTestBot.Data;

namespace TelegramTestBot
{
    class Program
    {
        static void Main(string[] args)
        {
            BotLogic bot = new BotLogic();
            bot.Initialize();
            bot.Start();
            

            Console.ReadLine();

            bot.Stop();
            
        }
    }
}