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
    public class ProductTest1
        {
        [TestMethod]
        
        public void AddTest()
            {
            //Crea una lista de 3 items
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


            //Comprueba que el primer objeto de la lista tenga el nombre que se le ha asignado
            //Assert
          
            Assert.AreEqual(manager.GetAll().First().ProductName, "producto1");
           
            }
        }
    }
