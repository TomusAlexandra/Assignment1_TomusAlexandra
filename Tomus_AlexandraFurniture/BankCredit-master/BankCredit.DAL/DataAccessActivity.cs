using BankCredit.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankCredit.DAL
{
    public class DataAccessActivity
    {

        public string connString;

        public DataAccessActivity()
        {
            connString = "Server=127.0.1;Port=3306;Database=manager;Uid=root;Pwd=1234;";
        }


        public IList<Activity> RetrieveActivity(int idemployee, string data1, string data2)
        {
            IList<Activity> activityList = new List<Activity>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                // string statement = "SELECT * FROM activity WHERE"+idemployee+"; ";
                //string statement = "SELECT * FROM activity WHERE'" + idemployee + "';";

                string statement = "SELECT * FROM activity WHERE IdEmployee='" + idemployee + "'and deliverydate > '"+data1+"' and deliverydate < '"+data2+"';";
                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Activity activity = new Activity();
                        activity.ID = reader.GetInt32("ID");
                        activity.IdEmployee = reader.GetInt32("IdEmployee");
                        activity.AddOp = reader.GetInt32("AddOp");
                        activity.UpdateOp = reader.GetInt32("UpdateOp");
                        activity.Viewproduct = reader.GetInt32("Viewproduct");
                        activity.DeliveryDate = reader.GetDateTime("DeliveryDate").ToString();
                        activityList.Add(activity);
                        Console.WriteLine("asa:", activity.ID);
                    }
                }
            }

            return activityList;
        }



        public void AddActivity(Activity activity)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO activity(ID, idemployee, addop, updateop, viewproduct, deliverydate) VALUES(@ID, @idemployee, @addop, @updateop, @viewproduct, @deliverydate)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@ID", activity.ID);
                cmd.Parameters.AddWithValue("@idEmployee", activity.IdEmployee);
                cmd.Parameters.AddWithValue("@addop", activity.AddOp);
                cmd.Parameters.AddWithValue("@updateop", activity.UpdateOp);
                cmd.Parameters.AddWithValue("@viewproduct", activity.Viewproduct);
                cmd.Parameters.AddWithValue("@deliverydate", activity.DeliveryDate);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
