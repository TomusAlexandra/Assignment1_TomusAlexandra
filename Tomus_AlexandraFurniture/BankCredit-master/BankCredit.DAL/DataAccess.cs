using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Furniture.Models;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace Furniture.DAL
{
    public class DataAccess
    {
        private string connString;

        public DataAccess()
        {
            connString = "Server=127.0.1;Port=3306;Database=manager;Uid=root;Pwd=1234;";
        }





        public User GetUser(string userName)
        {

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM Users where UserName=\""+ userName +"\";";
                MySqlCommand cmd = new MySqlCommand(statement,conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    {
                        User user = new User();
                        user.ID = reader.GetInt32("Id");
                        user.UserName = reader.GetString("UserName");
                        user.Password = reader.GetString("Password");
                        user.firstName = reader.GetString("FirstName");
                        user.IsAdmin = reader.GetBoolean("IsAdmin");
                        user.lastName = reader.GetString("LastName");
                        user.DateOfBirth = reader.GetDateTime("DateOfBirth");

                        return user;
                    }
                }
            }

            return null;
        }

        public void AddUser(User user)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Users(UserName, Password, FirstName, LastName, IsAdmin, DateOfBirth) VALUES(@username, @password, @firstname, @lastname, @isadmin, @birthdate)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@username", user.UserName);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@firstname", user.firstName);
                cmd.Parameters.AddWithValue("@lastname", user.lastName);
                cmd.Parameters.AddWithValue("@isadmin", user.IsAdmin);
                cmd.Parameters.AddWithValue("@birthdate", user.DateOfBirth);

                cmd.ExecuteNonQuery();
            }
        }

        public IList<Account> GetAccountsForUser(int userID)
        {
            IList<Account> creditList = new List<Account>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM Accounts where userid="+ userID + "; ";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Account credit = new Account();
                        credit.ID = reader.GetInt32("Id");
                        credit.Number = reader.GetString("Number");
                        credit.Value = reader.GetDouble("Value");
                        creditList.Add(credit);
                    }
                }
            }

            return creditList;
        }
    }
}
