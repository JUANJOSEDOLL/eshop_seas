using EShop.CORE;
using EShop.CORE.Contracts;

using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EShop.DAL
    {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
        {
        #region Connection
        public ApplicationDbContext()
           : base("DefaultConnection", throwIfV1Schema: false)
            {
            } 
        #endregion

        #region Create
        public static ApplicationDbContext Create()
            {
            return new ApplicationDbContext();
            } 
        #endregion

        #region Colecciones
        /// <summary>
        /// Colección persistible de categorías 
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Colección persistible de imágenes
        /// </summary>
        public DbSet<Image> Images { get; set; }

        /// <summary>
        /// Colección persistible de órdenes
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Colección persistible de detalle ordenes
        /// </summary>
        public DbSet<OrderDetail> OrderDetails { get; set; }

        /// <summary>
        /// Colección persistible de productos
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Colección persistible de items de carrito
        /// </summary>

        public DbSet<CartItem> CartItems { get; set; }

        #endregion
        }
    }
