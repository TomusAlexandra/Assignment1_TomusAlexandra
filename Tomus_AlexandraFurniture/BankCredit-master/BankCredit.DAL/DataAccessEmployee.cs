using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Furniture.Models;
using MySql.Data.MySqlClient;

namespace BankCredit.DAL
{
  public  class DataAccessEmployee
    {

        public string connString;

        public DataAccessEmployee()
        {
            connString = "Server=127.0.1;Port=3306;Database=manager;Uid=root;Pwd=1234;";
        }


        public IList<Employee> RetrieveEmployee()
        {
            IList<Employee> employeeList = new List<Employee>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM Users";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee();
                        employee.ID = reader.GetInt32("Id");
                        employee.UserName = reader.GetString("UserName");
                       // employee.Password = reader.GetString("Password");
                        employee.firstName = reader.GetString("FirstName");
                        employee.lastName = reader.GetString("LastName");
                       // employee.IsAdmin = reader.GetBoolean("isAdmin");
                       //s employee.DateOfBirth = reader.GetDateTime("DateOfBirth");
                        employeeList.Add(employee);
                    }
                }
            }

             return employeeList;
        }



        public void AddEmployee(Employee employee)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Users(UserName, Password, FirstName, LastName, IsAdmin, DateOfBirth) VALUES(@username, @password, @firstname, @lastname, @isadmin, @birthdate)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@username", employee.UserName);
                cmd.Parameters.AddWithValue("@password", employee.Password);
                cmd.Parameters.AddWithValue("@firstname", employee.firstName);
                cmd.Parameters.AddWithValue("@lastname", employee.lastName);
                cmd.Parameters.AddWithValue("@isadmin", employee.IsAdmin);
                cmd.Parameters.AddWithValue("@birthdate", employee.DateOfBirth);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(Employee employee)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM Users WHERE username = @username";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@username", employee.UserName);
                cmd.Parameters.AddWithValue("@password", employee.Password);
                cmd.Parameters.AddWithValue("@firstname", employee.firstName);
                cmd.Parameters.AddWithValue("@lastname", employee.lastName);
                cmd.Parameters.AddWithValue("@isadmin", employee.IsAdmin);
                cmd.Parameters.AddWithValue("@birthdate", employee.DateOfBirth);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE Users SET password = @password, firstname = @firstname, lastname = @lastname WHERE username = @username";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@username", employee.UserName);
                cmd.Parameters.AddWithValue("@password", employee.Password);
                cmd.Parameters.AddWithValue("@firstname", employee.firstName);
                cmd.Parameters.AddWithValue("@lastname", employee.lastName);
                cmd.Parameters.AddWithValue("@isadmin", employee.IsAdmin);
                cmd.Parameters.AddWithValue("@birthdate", employee.DateOfBirth);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
