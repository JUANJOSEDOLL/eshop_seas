namespace EShop.Models
    {
    public class CartItemModel
        {
        /// <summary>
        /// Identificador de id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Identificador de id del carrito
        /// </summary>
        public string CartId { get; set; }
        /// <summary>
        /// Identificador de cantidad de la linea
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Identificador de nombre
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// Identificador de precio
        /// </summary>
        public float ProductPrice { get; set; }
        /// <summary>
        /// Identificador de fecha
        /// </summary>
        public System.DateTime DateCreated { get; set; }
        /// <summary>
        /// Identificador de id de producto
        /// </summary>
        public int Product_Id { get; set; }

        }
    }