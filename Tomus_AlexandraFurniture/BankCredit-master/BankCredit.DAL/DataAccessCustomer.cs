using Farniture.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankCredit.DAL
{
   public  class DataAccessCustomer
    {


        public string connString;

        public DataAccessCustomer()
        {
            connString = "Server=127.0.1;Port=3306;Database=manager;Uid=root;Pwd=1234;";
        }



        public IList<Customer> RetrieveCustomer()
        {
            IList<Customer> customerList = new List<Customer>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM Customer";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Customer customer = new Customer();
                        customer.ID = reader.GetInt32("ID");
                        customer.Cnp = reader.GetString("Cnp");
                        customer.Address = reader.GetString("Address");

                        customerList.Add(customer);
                    }
                }
            }

            return customerList;
        }
    }
}
