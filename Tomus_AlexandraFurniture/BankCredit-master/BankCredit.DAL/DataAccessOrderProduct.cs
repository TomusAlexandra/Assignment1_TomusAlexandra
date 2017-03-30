using BankCredit.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankCredit.DAL
{
    public class DataAccessOrderProduct
    {

        public string connString;

        public DataAccessOrderProduct()
        {
            connString = "Server=127.0.1;Port=3306;Database=manager;Uid=root;Pwd=1234;";
        }



        public IList<OrderProduct> RetrieveOrderProduct(int idO)
        {
            IList<OrderProduct> productList = new List<OrderProduct>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                    string statement = "SELECT * FROM OrderProduct WHERE IdOrder='" + idO + "';";
              //  string statement = "SELECT * FROM OrderProduct ";
                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OrderProduct product = new OrderProduct();
                        product.ID = reader.GetInt32("ID");
                        product.IdOrder = reader.GetInt32("IdOrder");
                        product.IdProduct = reader.GetInt32("IdProduct");
                    //    product.Stock = reader.GetInt32("Stock");

                        productList.Add(product);
                    }
                }
            }

            return productList;
        }



        public void AddProductOrder(OrderProduct product)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO OrderProduct(id, IdOrder, IdProduct) VALUES(@id, @IdOrder, @IdProduct)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", product.ID);
                cmd.Parameters.AddWithValue("@IdOrder", product.IdOrder);
                cmd.Parameters.AddWithValue("@IdProduct", product.IdProduct);
              //  cmd.Parameters.AddWithValue("@stock", product.Stock);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateProductOrder(OrderProduct product)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE Product SET  stock=@stock WHERE id = @id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", product.ID);
                cmd.Parameters.AddWithValue("@IdOrder",product.IdOrder);
                cmd.Parameters.AddWithValue("@IdProduct", product.IdProduct);
              //  cmd.Parameters.AddWithValue("@stock", product.Stock);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProductOrder(OrderProduct product)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM OrderProduct WHERE id = @id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", product.ID);
                cmd.Parameters.AddWithValue("@IdOrder", product.IdOrder);
                cmd.Parameters.AddWithValue("@IdProduct", product.IdProduct);
                cmd.Parameters.AddWithValue("@stock", product.Stock);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
