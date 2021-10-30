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
    public class OrderDetailTest3
        {
        [TestMethod]

        public void AddTest()
            {
            //Crea una lista de 10 items asignándoa cada uno un id de orden, después
            //consultará cuantas instancias de detalle de orden pertenecen a una orden determinada
            //Arrange            
            Context context = new Context();
            OrderDetailManager manager = new OrderDetailManager(context);
            OrderDetail orderDetail1 = new OrderDetail { Order_Id = 1 };
            OrderDetail orderDetail2 = new OrderDetail { Order_Id = 2 };
            OrderDetail orderDetail3 = new OrderDetail { Order_Id = 3 };
            OrderDetail orderDetail4 = new OrderDetail { Order_Id = 1 };
            OrderDetail orderDetail5 = new OrderDetail { Order_Id = 8 };
            OrderDetail orderDetail6 = new OrderDetail { Order_Id = 3 };
            OrderDetail orderDetail7 = new OrderDetail { Order_Id = 7 };
            OrderDetail orderDetail8 = new OrderDetail { Order_Id = 2 };
            OrderDetail orderDetail9 = new OrderDetail { Order_Id = 3 };

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

            var itemCalculado= manager.GetAll().Where(x => x.Order_Id == 8).Count();
            var itemEsperado = 1;
            //consultará cuantas instancias de detalle de orden pertenecen a la orden de id 8, que ha de ser 1
            //Assert

            Assert.AreEqual(itemCalculado, itemEsperado);

            }
        }
    }
