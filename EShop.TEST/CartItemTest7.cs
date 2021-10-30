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
    public class CartItemTest7
        {
        [TestMethod]
        //Crea una lista de 3 items, los cuenta, elimina uno, los vuelve a contar, elimina otro,
        //vuelve a contarlo
        public void AddTest()
            {
            //Arrange            
            Context context = new Context();
            CartItemManager manager = new CartItemManager(context);
            CartItem cartItem1 = new CartItem { ProductName = "cartItemo1" };
            CartItem cartItem2 = new CartItem { ProductName = "cartItemo2" };
            CartItem cartItem3 = new CartItem { ProductName = "cartItemo3" };

            //Act
            manager.Add(cartItem1);
            manager.Add(cartItem2);
            manager.Add(cartItem3);

            //el resultado del conteo ha de ir descendiendo de 3 a 0
            //Assert
          
            Assert.AreEqual(manager.GetAll().Count(), 3);
            manager.Remove(cartItem1);
            Assert.AreEqual(manager.GetAll().Count(), 2);
            manager.Remove(cartItem2);
            Assert.AreEqual(manager.GetAll().Count(), 1);
            manager.Remove(cartItem3);
            Assert.AreEqual(manager.GetAll().Count(), 0);
            }
        }
    }
