using System;
using System.Linq;
using TelegramTestBot.Models;
using TelegramTestBot.OrderInstructions;
using TelegramTestBot.ORM;

namespace TelegramTestBot.Repositories
{
    public class OrderRepository : IOrderRepository

    {
        public void CreateOrder(Order order)
        {
            using (OrdersContext db = new OrdersContext())
            {
                db.OrdersDataBase.Add(order);
                db.SaveChanges();
            }
        }

        public Order[] GetOrdersByUserId(long userId)
        {
            using (OrdersContext db = new OrdersContext())
            {
                var result = db.OrdersDataBase.AsQueryable<Order>().Where(order => order.UserId == userId);
                return result.ToArray();
            }
        }

        public Order GetOrderById(Guid orderId)
        {
            using (OrdersContext db = new OrdersContext())
            {
                var result = db.OrdersDataBase.AsQueryable<Order>().FirstOrDefault(order => order.Id == orderId);
                return result;
            }
        }
    }
}