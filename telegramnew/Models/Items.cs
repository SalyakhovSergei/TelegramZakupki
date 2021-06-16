using System;

namespace TelegramTestBot.Models
{
    public class Items
    {
        public Guid OrderId { get; set; }
        public Guid ItemId { get; set; }
        public int Qty { get; set; }
    }
}