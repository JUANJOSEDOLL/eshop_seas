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
    public class ProductTest3
        {
        [TestMethod]
        //Crea una lista de 3 items, los cuenta, elimina uno, los vuelve a contar, elimina otro,
        //vuelve a contarlo
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

            //el resultado del conteo ha de ir descendiendo de 3 a 0
            //Assert
          
            Assert.AreEqual(manager.GetAll().Count(), 3);
            manager.Remove(product1);
            Assert.AreEqual(manager.GetAll().Count(), 2);
            manager.Remove(product2);
            Assert.AreEqual(manager.GetAll().Count(), 1);
            manager.Remove(product3);
            Assert.AreEqual(manager.GetAll().Count(), 0);
            }
        }
    }
