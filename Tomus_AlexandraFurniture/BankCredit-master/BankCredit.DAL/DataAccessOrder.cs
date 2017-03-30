using Furniture.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankCredit.DAL
{
   public class DataAccessOrder
    {

        public string connString;

        public DataAccessOrder()
        {
            connString = "Server=127.0.1;Port=3306;Database=manager;Uid=root;Pwd=1234;";
        }



        public IList<Order> RetrieveOrder()
        {
            IList<Order> orderList = new List<Order>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM Orders";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Order order = new Order();
                        order.ID = reader.GetInt32("ID");
                        order.IdCustomer = reader.GetInt32("IdCustomer");
                        order.IdEmployee = reader.GetInt32("IdEmployee");
                        order.ShippindAddress= reader.GetString("ShippindAddress");
                        order.IdentificationNr = reader.GetInt32("identificationNr");
                        order.DeliveryDate = reader.GetDateTime("DeliveryDate");
                        order.Status = reader.GetString("Status");

                        orderList.Add(order);
                    }
                }
            }

            return orderList;
        }

        public void AddOrder(Order order)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
               cmd.CommandText = "INSERT INTO Orders (ID,IdCustomer,IdEmployee,ShippindAddress,IdentificationNr,DeliveryDate,Status) VALUES(@ID,@IdCustomer,@IdEmployee,@ShippindAddress,@IdentificationNr,@DeliveryDate,@Status)";
            
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@ID", order.ID);
                cmd.Parameters.AddWithValue("@IdCustomer", order.IdCustomer);
                cmd.Parameters.AddWithValue("@IdEmployee", order.IdEmployee);
                cmd.Parameters.AddWithValue("@ShippindAddress", order.ShippindAddress);
                cmd.Parameters.AddWithValue("@IdentificationNr", order.IdentificationNr);
                cmd.Parameters.AddWithValue("@DeliveryDate", order.DeliveryDate);
                cmd.Parameters.AddWithValue("@Status", order.Status);
                


              

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateOrder(Order order)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE Orders SET  Status=@Status WHERE ID = @ID";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@ID", order.ID);
                cmd.Parameters.AddWithValue("@IdCustomer", order.IdCustomer);
                cmd.Parameters.AddWithValue("@IdEmployee", order.IdEmployee);
                cmd.Parameters.AddWithValue("@ShippindAddress", order.ShippindAddress);
                cmd.Parameters.AddWithValue("@IdentificationNr", order.IdentificationNr);
                cmd.Parameters.AddWithValue("@DeliveryDate", order.DeliveryDate);
                cmd.Parameters.AddWithValue("@Status", order.Status);

                cmd.ExecuteNonQuery();
            }
        }




    }
}
