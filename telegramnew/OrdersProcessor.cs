using System;
using System.Collections.Generic;
using System.Linq;
using TelegramTestBot.Data;
using TelegramTestBot.Models;
using TelegramTestBot.OrderInstructions;

namespace TelegramTestBot
{
    public class OrdersProcessor
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersProcessor(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void CreateNewOrder(long userId)
        {
           if (_orderRepository.GetOrdersByUserId(userId).Any(o => o.Status == OrderStatus.Editing))
            {
                return;
            }
            _orderRepository.CreateOrder(new Order() { Id = Guid.NewGuid(), UserId = userId, Status = OrderStatus.Editing, Items = new List<Items>()});
        }

        public int AppendItemToOrder(long userId, Guid itemId)
        {
            var order = _orderRepository.GetOrdersByUserId(userId).FirstOrDefault(o => o.Status == OrderStatus.Editing);
            var id = order.Items.Select(o => o.ItemId);
            if (id.Contains(itemId))
            {
                order.Items.FirstOrDefault(o => o.ItemId == itemId).Qty++;
            }
            else
            {
                order.Items.FirstOrDefault(o => o.ItemId == itemId).Qty = 1;
            }
            
            _orderRepository.UpdateOrder(order);

            return order.Items[itemId];
        }
    }
}