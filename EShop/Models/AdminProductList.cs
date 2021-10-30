namespace EShop.Models
    {
    public class AdminProductList
        {
        /// <summary>
        /// Identificador de id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Identificador de nombre
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// Identificador de descripcion
        /// </summary>
        public string ProductDescription { get; set; }
        /// <summary>
        /// Identificador de precio
        /// </summary>
        public float ProductPrice { get; set; }
        /// <summary>
        /// Identificador de stock
        /// </summary>
        public int Stock { get; set; }


        }
    }