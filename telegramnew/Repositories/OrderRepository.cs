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
 
        public OrderRepository ()
        {
            sql = new SqlConnection (BotCredentials.connectionstring);
        }

        public async void CreateOrder(Order order)
        {
            if (sql.State == ConnectionState.Closed)
            {
                sql.Open();
                SqlCommand command = new SqlCommand($"INSERT INTO Orders (Id, UserId, Products) values ('{order.Id}', '{order.UserId}', '{JsonConvert.SerializeObject(order.Items)}')", sql);
                await command.ExecuteNonQueryAsync();
                sql.Close();
            }
        }

        public async Order [] GetOrdersByUserIdAsync (string userId)
        {
            sql.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("", sql);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            sql.Close();

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



    }
}
