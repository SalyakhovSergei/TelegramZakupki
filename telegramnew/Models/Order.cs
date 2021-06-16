using System;
using System.Collections.Generic;
using TelegramTestBot.Data;

namespace TelegramTestBot.Models
{
    public class Order
    {
        public Guid Id { get; set; } 
        public long UserId { get; set; }
        public List<Items> Items { get; set; }
        
        public OrderStatus Status { get; set; }
    }


}
