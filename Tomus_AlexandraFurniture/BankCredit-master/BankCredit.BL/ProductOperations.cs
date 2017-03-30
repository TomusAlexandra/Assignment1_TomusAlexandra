using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Furniture.Models;
using Furniture.DAL;

namespace BankCredit.BL
{
    public class ProductOperations
    {

        public void AddProduct(Product product)
        {

            DataAccessProduct dal = new DataAccessProduct();
            dal.AddProductTest(product);
        }

        public void UpdateProduct(Product product)
        {

            DataAccessProduct dal = new DataAccessProduct();
            dal.UpdateProduct(product);
        }
        public void UpdateProduct(int idProduct,int stock)
        {

            DataAccessProduct dal = new DataAccessProduct();
            dal.UpdateProduct(idProduct,stock);
        }

        public void DeleteProduct(Product product)
        {

            DataAccessProduct dal = new DataAccessProduct();
            dal.DeleteProduct(product);
        }

        public IList<Product> RetrieveProductList()
        {
            DataAccessProduct dal = new DataAccessProduct();
            return dal.RetrieveProduct();
        }


        public IList<Product> RetrieveProductOrderList(int idProduct)
        {
            DataAccessProduct dal = new DataAccessProduct();
            return dal.RetrieveProductOrder(idProduct);
        }

      
    }
    }
