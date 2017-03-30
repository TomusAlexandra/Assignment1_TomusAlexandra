using BankCredit.DAL;
using BankCredit.Models;
using Furniture.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankCredit.BL
{
  public  class OrderProductOperations
    {
        public void AddProductOrder(OrderProduct product)
        {

            DataAccessOrderProduct dal = new DataAccessOrderProduct();
            dal.AddProductOrder(product);
        }

        public void UpdateProductOrder(OrderProduct product)
        {

            DataAccessOrderProduct dal = new DataAccessOrderProduct();
            dal.UpdateProductOrder(product);
        }

        public void DeleteProductOrder(OrderProduct product)
        {

            DataAccessOrderProduct dal = new DataAccessOrderProduct();
            dal.DeleteProductOrder(product);
        }

        public IList<OrderProduct> RetrieveOrderProductList(int idOrder)
        {
            DataAccessOrderProduct dal = new DataAccessOrderProduct();
            return dal.RetrieveOrderProduct(idOrder);
        }
    }
}
