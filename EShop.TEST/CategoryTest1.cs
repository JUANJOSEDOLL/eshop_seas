﻿using EShop.APPLICATION;
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
    public class CategoryTest1
        {
        [TestMethod]

        public void AddTest()
            {
            //Crea una lista de 3 categorias
            //Arrange            
            Context context = new Context();
            CategoryManager manager = new CategoryManager(context);
            Category category1 = new Category { CategoryName = "category1" };
            Category category2 = new Category { CategoryName = "category2" };
            Category category3 = new Category { CategoryName = "category3" };

            //Act
            manager.Add(category1);
            manager.Add(category2);
            manager.Add(category3);


            //Comprueba que el se efectue un recuento correcto
            //Assert

            Assert.AreEqual(manager.GetAll().Count(), 3);

            }
        }
    }
