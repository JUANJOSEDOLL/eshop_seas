namespace EShop.Models
    {
    public class ProductForGallery
        {
        /// <summary>
        /// Identificador de la id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Identificador de nombre del producto
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// Identificador de precio
        /// </summary>
        public float ProductPrice { get; set; }
        /// <summary>
        /// Identificador de nombre imagen
        /// </summary>
        public string ImageName { get; set; }
        /// <summary>
        /// Identificador de la imagen principal
        /// </summary>
        public string ImagePath { get; set; }
        }
    }