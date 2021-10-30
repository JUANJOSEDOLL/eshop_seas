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
	public class OrderTest1
        {
        [TestMethod]

        public void AddTest()
            {
            //Crea una lista de 3 items y obtiene el total de los importe de los total factura
           
            //Arrange            
            Context context = new Context();
            OrderManager manager = new OrderManager(context);
            Order Order1 = new Order { Id = 1, TotalInvoice = 100 };
            Order Order2 = new Order { Id = 2, TotalInvoice = 100 };
            Order Order3 = new Order { Id = 3, TotalInvoice = 1000 };

            //Act
            manager.Add(Order1);
            manager.Add(Order2);
            manager.Add(Order3);

            var calculated = manager.GetAll().Sum(x=>x.TotalInvoice);
            var expected = 1200;

            //var calculated = manager.GetById(3).TotalInvoice.ToString();
            //var expected = "12000";
            //Comprueba que el importe del total los 3 items sea el correcto esperado de 1200
            //Assert

            Assert.AreEqual(calculated, expected);
            }
        }
    }
