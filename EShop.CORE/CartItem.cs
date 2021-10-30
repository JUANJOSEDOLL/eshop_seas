using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.CORE
    {
    #region declaración Clase y propiedades carrito
    public class CartItem
        {
        /// <summary>
        /// Identificador único de la linea de carrito
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador del carrito en una sesión
        /// </summary>
        public string CartId { get; set; }

        /// <summary>
        /// Cantidad de producto
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Nombre del producto
        /// </summary>        
        public string ProductName { get; set; }

        /// <summary>
        /// Precio del producto para ese detalle de orden
        /// </summary>
        public float ProductPrice { get; set; }

        public System.DateTime DateCreated { get; set; }

        /// <summary>
        /// Producto al que pertenece el carrito
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Identificador del producto al que pertenece el carrito
        /// </summary>
        [ForeignKey("Product")]
        public int Product_Id { get; set; }

        } 
    #endregion
    }