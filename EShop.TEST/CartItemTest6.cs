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
    public class CartItemTest6
        {
        [TestMethod]
        public void AddTest()
            {
            //Crea una lista de 3 cartItems y los cuenta
            //Arrange            
            Context context = new Context();
            CartItemManager manager = new CartItemManager(context);
            CartItem cartItem1 = new CartItem { ProductName = "cartItem1" };
            CartItem cartItem2 = new CartItem { ProductName = "cartItem2" };
            CartItem cartItem3 = new CartItem { ProductName = "cartItem3" };

            //Act
            manager.Add(cartItem1);
            manager.Add(cartItem2);
            manager.Add(cartItem3);

            //Comprueba que el sistema cuenta todos los item entrados en este caso 3
            //Assert
            Assert.AreEqual(manager.GetAll().Count(), 3);
         
          
            }
        }
    }
