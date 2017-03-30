using BankCredit.DAL;
using Furniture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankCredit.BL
{
   public  class OrdersOperations
    {

        public IList<Order> RetrieveOrderList()
        {
            DataAccessOrder dal = new DataAccessOrder();
            return dal.RetrieveOrder();
        }

        public void AddOrder(Order order)
        {

            DataAccessOrder dal = new DataAccessOrder();
            dal.AddOrder(order);
        }

        public void UpdateOrder(Order order)
        {

            DataAccessOrder dal = new DataAccessOrder();
            dal.UpdateOrder(order);
        }
    }
}
