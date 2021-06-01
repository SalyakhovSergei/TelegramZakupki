using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramTestBot.Models;

namespace TelegramTestBot
{
    public class ApplicationContext : DbContext
    {
        public DbSet <Order> OrdersDataBase { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(BotCredentials.connectionstring);
        }

    }
}
