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
    public class CartItemTest4
        {
        [TestMethod]

        public void AddTest()
            {
            //Crea una lista de 3 items con precio y cantidad y comprueba el total de items
            //Arrange            
            Context context = new Context();
            CartItemManager manager = new CartItemManager(context);
            CartItem cartItem1 = new CartItem { ProductPrice = 1, Quantity = 30 };
            CartItem cartItem2 = new CartItem { ProductPrice = 15, Quantity = 2 };
            CartItem cartItem3 = new CartItem { ProductPrice = 10, Quantity = 4 };

            //Act
            manager.Add(cartItem1);
            manager.Add(cartItem2);
            manager.Add(cartItem3);


            //Comprueba que el comprueba el total de items
            //Assert

            
            Assert.AreEqual(manager.GetAll().Count(), 3);
            }
        }
    }
