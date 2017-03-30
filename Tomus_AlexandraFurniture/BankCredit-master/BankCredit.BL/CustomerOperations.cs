using BankCredit.DAL;
using Farniture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankCredit.BL
{
    public class CustomerOperations
    {
        public IList<Customer> RetrieveCustomerList()
        {
            DataAccessCustomer dal = new DataAccessCustomer();
            return dal.RetrieveCustomer();
        }

    }
}
