using EShop.APPLICATION;
using EShop.CORE;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EShop.TEST
    {
    [TestClass]
    public class ProductTest4
        {
        [TestMethod]

        //Lista una serie de items y comprueba el nombre del último
        public void AddTest()
            {
            //Arrange            
            Context context = new Context();
            ProductManager manager = new ProductManager(context);
            Product product1 = new Product { ProductName = "producto1" };
            Product product2 = new Product { ProductName = "producto2" };
            Product product3 = new Product { ProductName = "producto3" };

            //Act
            manager.Add(product1);
            manager.Add(product2);
            manager.Add(product3);

            //Assert

          

        Assert.AreEqual(manager.GetAll().Last().ProductName, "producto3");
           

            }
        }
    }
