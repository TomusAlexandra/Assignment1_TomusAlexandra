using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Furniture.BL;
using Furniture.Models;
using Furniture.DAL;
using BankCredit.BL;

namespace Furniture.UnitTests.BL
{
    [TestClass]
    public class ProductOp
    {
        [TestMethod]
        public void AddProduct()
        {
            DataAccessProduct op = new DataAccessProduct();
            Product product = new Product(77,"door","big","red",255,50,2);
            bool rez = op.AddProductTest(product);
            Assert.IsTrue(rez);
        }

        [TestMethod]
        public void DeleteProduct()
        {
            DataAccessProduct op = new DataAccessProduct();
            Product product = new Product(77, "door", "big", "red", 255, 50, 2);
            bool rez = op.DeleteProductTest(product);
            Assert.IsTrue(rez);
        }
    }
}
