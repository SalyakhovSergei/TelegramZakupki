using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramTestBot.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public long UserId { get; set; }
        public Dictionary<Guid, int> Items { get; set; }


    }


}
