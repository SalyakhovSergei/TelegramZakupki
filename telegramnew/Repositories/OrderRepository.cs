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
        private readonly SqlConnection _sql;
        private TelegramContext _telegramContext = new TelegramContext();

        public OrderRepository ()
        {
            _sql = new SqlConnection (BotCredentials.connectionstring);
        }

        public async void CreateOrder(Order order)
        {
            //applicationContext.OrdersDataBase.Add(order);


            if (_sql.State == ConnectionState.Closed)
            {
                _sql.Open();
                SqlCommand command = new SqlCommand($"INSERT INTO Orders (Id, UserId, Products) values ('{order.Id}', '{order.UserId}', '{JsonConvert.SerializeObject(order.Items)}')", _sql);
                await command.ExecuteNonQueryAsync();
                _sql.Close();
            }

        }

        public async Order [] GetOrdersByUserIdAsync (string userId)
        {
            //var ordersByUserId = from order in applicationContext.OrdersDataBase
            //                     where order.UserId == userId
            //                     select order;

            _sql.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter($"SELECT * FROM Orders WHERE UserID = {userId}", _sql);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            _sql.Close();

            List<Order> ordersByUserId = new List<Order>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                foreach (var item in dt.Rows[i].ItemArray)
                {
                    ordersByUserId.Add((Order)item);
                }
            }

            return ordersByUserId.ToArray();
        }

        public async Task<Order> OrderTask(string UserId)
        {

        }



    }
}
