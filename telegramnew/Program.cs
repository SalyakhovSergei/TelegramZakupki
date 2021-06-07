using System;

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

           
            
        }
    }
}