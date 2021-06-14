using System;
using TelegramTestBot.Models;

namespace TelegramTestBot.OrderInstructions
{
    public interface IOrderRepository
    {
        public void CreateOrder (Order order);
        
        public Order[] GetOrdersByUserId (long userId);

        public Order GetOrderById(Guid orderId);

        public void UpdateOrder(Order order);
    }
}