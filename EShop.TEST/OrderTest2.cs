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
	public class OrderTest2
        {
        [TestMethod]

        public void AddTest()
            {
            //Crea una lista de 9 items y cuenta los items que hay
            //Arrange            
            Context context = new Context();
            OrderManager manager = new OrderManager(context);
            Order Order1 = new Order { Id = 1, TotalInvoice = 120, Status = (OrderStatus)2, User_Id="1" };
            Order Order2 = new Order { Id = 2, TotalInvoice = 1200, Status = (OrderStatus)3, User_Id = "1" };
            Order Order3 = new Order { Id = 3, TotalInvoice = 1120, Status = (OrderStatus)2, User_Id = "2"};
            Order Order4 = new Order { Id = 4, TotalInvoice = 1200, Status = (OrderStatus)0, User_Id = "1" };//<-
            Order Order5 = new Order { Id = 5, TotalInvoice = 12, Status = (OrderStatus)0, User_Id = "3" };
            Order Order6 = new Order { Id = 6, TotalInvoice = 10, Status = (OrderStatus)1, User_Id = "1"};
            Order Order7 = new Order { Id = 7, TotalInvoice = 1520, Status = (OrderStatus)2, User_Id = "2" };
            Order Order8 = new Order { Id = 8, TotalInvoice = 150, Status = (OrderStatus)3, User_Id = "4" };
            Order Order9 = new Order { Id = 9, TotalInvoice = 125, Status = (OrderStatus)0, User_Id = "1"};//<-

            //Act
            manager.Add(Order1);
            manager.Add(Order2);
            manager.Add(Order3);
            manager.Add(Order4);
            manager.Add(Order5);
            manager.Add(Order6);
            manager.Add(Order7);
            manager.Add(Order8);
            manager.Add(Order9);

            var calculado = manager.GetByUserId("1").Where(x => x.Status== (OrderStatus)0).Count() ;

            var esperado = 2;

            //Comprueba que el número de items del id de usuario 1  con la situación de su status a 0, sea 2
            //Assert

            Assert.AreEqual(calculado, esperado);


            }
        }
    }
