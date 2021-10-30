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
    public class CartItemTest5
        {
        [TestMethod]
        
        public void AddTest()
            {
            //Crea una lista de 3 items
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


            //Comprueba que el primer objeto de la lista tenga el nombre que se le ha asignado en este caso cartItem1
            //Assert
          
            Assert.AreEqual(manager.GetAll().First().ProductName, "cartItem1");
           
            }
        }
    }
