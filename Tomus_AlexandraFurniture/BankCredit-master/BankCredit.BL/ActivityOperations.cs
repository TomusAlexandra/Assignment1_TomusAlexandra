using BankCredit.DAL;
using BankCredit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankCredit.BL
{
   public class ActivityOperations
    {   
        public IList<Activity> RetrieveActivityList(int id, string data1, string data2)
        {   
            DataAccessActivity dal = new DataAccessActivity();
            return dal.RetrieveActivity(id,data1,data2);
        }

        public void AddActivity(Activity activity)
        {

            DataAccessActivity dal = new DataAccessActivity();
            dal.AddActivity(activity);
        }

       
    }
}
