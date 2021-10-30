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
    public class CartItemTest3
        {
        [TestMethod]

        public void AddTest()
            {
            //Crea una lista de 3 items con precio y cantidad y comprueba que se calcule el total factura del carrito correctamente
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


            //Comprueba que el importe el total factura sea el correcto esperado de 121
            //Assert

            Assert.AreEqual(manager.GetAll().Sum(x => x.Quantity * x.ProductPrice) * 1.21, 121);

            }
        }
    }
