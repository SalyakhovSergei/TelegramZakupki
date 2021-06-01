using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramTestBot.Models;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using TelegramTestBot.Data;

namespace TelegramTestBot.Repositories
{
    public class OrderRepository
    {
        private readonly SqlConnection sql;
        private ApplicationContext applicationContext;

        public OrderRepository ()
        {
            sql = new SqlConnection (BotCredentials.connectionstring);
            applicationContext = new ApplicationContext();
        }

        public async void CreateOrder(Order order)
        {
            applicationContext.OrdersDataBase.Add(order);
        }

        public async Order [] GetOrdersByUserIdAsync (long userId)
        {
            var ordersByUserId = from order in applicationContext.OrdersDataBase 
                                  where order.UserId == userId 
                                   select order;

            return await ordersByUserId;


            //sql.Open();
            //SqlDataAdapter dataAdapter = new SqlDataAdapter("", sql);
            //DataTable dt = new DataTable();
            //dataAdapter.Fill(dt);
            //sql.Close();

            //List<Order> ordersByUserId = new List<Order>();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    foreach (var item in dt.Rows[i].ItemArray)
            //    {
            //        ordersByUserId.Add((Order)item);
            //    }
            //}

            //return ordersByUserId.ToArray();
        }



    }
}
