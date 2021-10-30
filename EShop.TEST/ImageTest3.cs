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
    public class ImageTest3
        {
        [TestMethod]
        
        public void AddTest()
            {
            //Crea una lista de 3 items
            //Arrange            
            Context context = new Context();
            ImageManager manager = new ImageManager(context);
            Image image1 = new Image { ImageName = "image1" };
            Image image2 = new Image { ImageName = "image2" };
            Image image3 = new Image { ImageName = "image3" };

            //Act
            manager.Add(image1);
            manager.Add(image2);
            manager.Add(image3);

           

            manager.Remove(image3);


            //Comprueba que el último objeto de la lista tenga el nombre que se le ha asignado
            //después de eliminar el que era el último
            //Assert
          
            Assert.AreEqual(manager.GetAll().Last().ImageName, "image2");
           
            }
        }
    }
