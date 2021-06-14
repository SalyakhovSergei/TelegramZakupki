using System;
using Moq;
using NUnit.Framework;
using Telegram.Bot.Exceptions;
using TelegramTestBot;
using TelegramTestBot.OrderInstructions;

namespace OrdersBot.Tests
{[TestFixture]
    public class OrdersBotTestsClass
    {
        [Test]
        public void BotLogicMustProvideCorrectAction()
        {
            var mockBotLogic = new Mock<IBotLogic>();
            // mockBotLogic.Setup(p => p.Start()).;

        }
    }
}