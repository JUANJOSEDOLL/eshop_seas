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
	public class OrderDetailTest1
        {
        [TestMethod]

        public void AddTest()
            {
            //Crea una lista de 3 items con precio y cantidad y comprueba que se calcule el total del producto
            //por el precio correctamente
            //Arrange            
            Context context = new Context();
            OrderDetailManager manager = new OrderDetailManager(context);
            OrderDetail orderDetail1 = new OrderDetail { Price = 1, Quantity = 1 };
            OrderDetail orderDetail2 = new OrderDetail { Price = 1, Quantity = 1 };
            OrderDetail orderDetail3 = new OrderDetail { Price = 1, Quantity = 1 };

            //Act
            manager.Add(orderDetail1);
            manager.Add(orderDetail2);
            manager.Add(orderDetail3);

            var calculated = manager.GetAll().Sum(x => x.Quantity * x.Price);
            var expected = 3;
            //Comprueba que el importe del total sea el correcto esperado de 3
            //Assert

            Assert.AreEqual(calculated, expected);
            }
        }
    }
