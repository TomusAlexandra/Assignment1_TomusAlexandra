using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankCredit.Models
{
   public class OrderProduct
    {

        public int ID { get; set; }
        public int IdOrder { get; set;}
        public int IdProduct { get; set; }
        public int Stock { get; set; }

    }
}
