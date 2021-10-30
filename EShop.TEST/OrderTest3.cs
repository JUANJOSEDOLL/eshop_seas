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
    public class OrderTest3
        {
        [TestMethod]

        public void AddTest()
            {
            //Crea una lista de 10 items asignándo a cada uno un id de cliente, después
            //consultará cuantas instancias de orden pertenecen a un cliente determinado
            //Arrange            
            Context context = new Context();
            OrderManager manager = new OrderManager(context);
            Order Order1 = new Order { User_Id = "1"};
            Order Order2 = new Order { User_Id = "2"};
            Order Order3 = new Order { User_Id = "3"};
            Order Order4 = new Order { User_Id = "8"};
            Order Order5 = new Order { User_Id = "4"};
            Order Order6 = new Order { User_Id = "2"};
            Order Order7 = new Order { User_Id = "1"};
            Order Order8 = new Order { User_Id = "4"};
            Order Order9 = new Order { User_Id = "5"};
            Order Order10 = new Order { User_Id = "5"};

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
            manager.Add(Order10);

            var itemCalculado= manager.GetAll().Where(x => x.User_Id == "8").Count();
            var itemEsperado = 1;
            //consultará cuantas instancias de orden pertenecen a la orden de id cliente 8, que ha de ser 1
            //Assert

            Assert.AreEqual(itemCalculado, itemEsperado);

            }
        }
    }
