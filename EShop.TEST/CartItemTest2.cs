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
	public class CartItemTest2
        {
        [TestMethod]

        public void AddTest()
            {
            //Crea una lista de 3 items con precio y cantidad y comprueba que se calcule la base imponible del carrito correctamente
            //Arrange            
            Context context = new Context();
            CartItemManager manager = new CartItemManager(context);
            CartItem cartItem1 = new CartItem { ProductPrice = 1 , Quantity=10};
            CartItem cartItem2 = new CartItem { ProductPrice = 5, Quantity = 2 };
            CartItem cartItem3 = new CartItem { ProductPrice = 10, Quantity = 1 };

            //Act
            manager.Add(cartItem1);
            manager.Add(cartItem2);
            manager.Add(cartItem3);


            //Comprueba que el se calcule la base imponible del carrito sea 30
            //Assert

            Assert.AreEqual(manager.GetAll().Sum(x=>x.Quantity*x.ProductPrice), 30);

            }
        }
    }
