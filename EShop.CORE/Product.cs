using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.CORE
    {
    #region Entidad de dominio de productos
    /// <summary>
    /// Entidad de dominio de productos
    /// </summary>    
    public class Product
        {
        /// <summary>
        /// Identificador del producto
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del producto
        /// </summary>        
        public string ProductName { get; set; }

        /// <summary>
        /// Descripcion del producto
        /// </summary>
        public string ProductDescription { get; set; }

        /// <summary>
        /// Precio del producto
        /// </summary>
        public float ProductPrice { get; set; }

        /// <summary>
        /// Colección de imagenes
        /// </summary>
        public virtual List<Image> Images { get; set; }

        /// <summary>
        /// Colección de detalle de ordenes
        /// </summary>
        public virtual List<OrderDetail> OrderDetails { get; set; }

        /// <summary>
        /// Categoria al que pertenece el producto
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Identificador de la categoria a la que pertenece el producto
        /// </summary>
        [ForeignKey("Category")]
        public int Category_Id { get; set; }

        /// <summary>
        /// Identificador del stock del producto
        /// </summary>
        public int Stock { get; set; }


        /// <summary>
        /// Identificador de la imagen principal
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Colección de detalle de CartItems
        /// </summary>
        public virtual List<CartItem> CartItems { get; set; }



        } 
    #endregion
    }
