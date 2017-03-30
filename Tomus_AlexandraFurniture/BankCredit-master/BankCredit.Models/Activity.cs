using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankCredit.Models
{
   public class Activity
    {

        public int ID { get; set; }
        public int IdEmployee { get; set; }
        public int AddOp { get; set; }
        public int UpdateOp { get; set; }
        public int Viewproduct { get; set; }
        public string DeliveryDate { get; set; }

    }
}
