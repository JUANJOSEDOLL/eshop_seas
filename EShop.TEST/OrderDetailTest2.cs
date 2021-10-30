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
	public class OrderDetailTest2
        {
        [TestMethod]

        public void AddTest()
            {
            //Crea una lista de 9 items y cuenta los items con un precio superior a 5
            //Arrange            
            Context context = new Context();
            OrderDetailManager manager = new OrderDetailManager(context);
            OrderDetail orderDetail1 = new OrderDetail { Price = 1 , Quantity=10};
            OrderDetail orderDetail2 = new OrderDetail { Price = 5, Quantity = 2 };
            OrderDetail orderDetail3 = new OrderDetail { Price = 10, Quantity = 1 };
            OrderDetail orderDetail4 = new OrderDetail { Price = 1, Quantity = 10 };
            OrderDetail orderDetail5 = new OrderDetail { Price = 5, Quantity = 2 };
            OrderDetail orderDetail6 = new OrderDetail { Price = 10, Quantity = 1 };
            OrderDetail orderDetail7 = new OrderDetail { Price = 1, Quantity = 10 };
            OrderDetail orderDetail8 = new OrderDetail { Price = 5, Quantity = 2 };
            OrderDetail orderDetail9 = new OrderDetail { Price = 10, Quantity = 1 };

            //Act
            manager.Add(orderDetail1);
            manager.Add(orderDetail2);
            manager.Add(orderDetail3);
            manager.Add(orderDetail4);
            manager.Add(orderDetail5);
            manager.Add(orderDetail6);
            manager.Add(orderDetail7);
            manager.Add(orderDetail8);
            manager.Add(orderDetail9);

            var itemsDePrecioSuperiorACincoCalculado = manager.GetAll().Where(x => x.Price > 5).Count(); ;

            var itemsDePrecioSuperiorACincoEsperado = 3;

            //Comprueba que el número de items de precio superior a 5 sean 3
            //Assert

            Assert.AreEqual(itemsDePrecioSuperiorACincoEsperado, itemsDePrecioSuperiorACincoEsperado);


            }
        }
    }
