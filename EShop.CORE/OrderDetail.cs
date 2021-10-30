using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.CORE
    {
    #region Clase de dominio del detalle de una orden
    /// <summary>
    /// Clase de dominio del detalle de una orden
    /// </summary>
    public class OrderDetail
        {
        /// <summary>
        /// Identificador del detalle de una orden
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador del nombre del producto
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Precio del producto para ese detalle de orden
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Cantidad de producto para ese detalle de orden
        /// Son unidades enteras
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Producto que recoge esta linea de pedido
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Identificador del producto que se inserta en el detalle del pedido
        /// </summary>
        [ForeignKey("Product")]
        public int Product_Id { get; set; }

        /// <summary>
        /// Número de factura que se le asigna al detalle
        /// </summary>
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// Orden  a la que pertenece esta linea de pedido
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Identificador de la orden a la que pertenece esta linea de pedido
        /// </summary>
        [ForeignKey("Order")]
        public int Order_Id { get; set; }

        } 
    #endregion
    }