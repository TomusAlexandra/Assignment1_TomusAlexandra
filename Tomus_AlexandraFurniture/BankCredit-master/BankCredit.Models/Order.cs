using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Furniture.Models
{
   public class Order
    {
        public int ID { get; set; }
        public int IdCustomer { get; set; }
        public int IdEmployee{ get; set; }
        public string ShippindAddress { get; set; }
        public int IdentificationNr { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Status { get; set; }

    }
}
