using EShop.CORE;
using EShop.CORE.Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;


namespace EShop.TEST
    {
    public class Context : IApplicationDbContext
        {
        private Mock<IApplicationDbContext> context = null;
        private List<Category> CategoryList = new List<Category>();
        private List<Product> ProductList = new List<Product>();
        private List<Image> ImageList = new List<Image>();
        private List<CartItem> CartItemList = new List<CartItem>();
        private List<OrderDetail> OrderDetailList = new List<OrderDetail>();
        private List<Order> OrderList = new List<Order>();
        
        public Context()
            {
            context = new Mock<IApplicationDbContext>();

            var mockCategory = CreateMock<Category>(CategoryList);
            context.Setup(m => m.Set<Category>()).Returns(mockCategory.Object);

            var mockProduct = CreateMock<Product>(ProductList);
            context.Setup(m => m.Set<Product>()).Returns(mockProduct.Object);

            var mockImage = CreateMock<Image>(ImageList);
            context.Setup(m => m.Set<Image>()).Returns(mockImage.Object);

            var mockCartItem = CreateMock<CartItem>(CartItemList);
            context.Setup(m => m.Set<CartItem>()).Returns(mockCartItem.Object);

            var mockOrderDetail = CreateMock<OrderDetail>(OrderDetailList);
            context.Setup(m => m.Set<OrderDetail>()).Returns(mockOrderDetail.Object);

            var mockOrder = CreateMock<Order>(OrderList);
            context.Setup(m => m.Set<Order>()).Returns(mockOrder.Object);

           
            context.Setup(m => m.SaveChanges()).Returns(0);
            }
        public System.Data.Entity.DbSet<T> Set<T>() where T : class
            {
            return context.Object.Set<T>();
            }

        public IApplicationDbContext Create()
            {
            return this;
            }

        public System.Data.Entity.Infrastructure.DbEntityEntry<T> Entry<T>(T entity) where T : class
            {
            return context.Object.Entry<T>(entity);
            }

        public int SaveChanges()
            {
            return context.Object.SaveChanges();
            }

        public Mock<DbSet<T>> CreateMock<T>(List<T> list)
            where T : class
            {
            var result = new Mock<DbSet<T>>();
            result.As<IQueryable<T>>().Setup(m => m.Provider).Returns(list.AsQueryable().Provider);
            result.As<IQueryable<T>>().Setup(m => m.Expression).Returns(list.AsQueryable().Expression);
            result.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(list.AsQueryable().ElementType);
            result.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(list.GetEnumerator());
            result.Setup(x => x.AsNoTracking()).Returns(result.Object);
            result.Setup(x => x.Add(It.IsAny<T>())).Callback<T>((s) => list.Add(s));
            result.Setup(x => x.Remove(It.IsAny<T>())).Callback<T>((s) => list.Remove(s));
            return result;
            }
        }

    }
