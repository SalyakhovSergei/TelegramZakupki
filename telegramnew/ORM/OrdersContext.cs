using Microsoft.EntityFrameworkCore;
using TelegramTestBot.Models;

namespace TelegramTestBot.ORM
{
    public class OrdersContext: DbContext
    {
        public DbSet <Order> OrdersDataBase { get; set; }

        public OrdersContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(BotCredentials.connectionstring);
        }
    }
}
