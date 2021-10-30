using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.CORE
    {
    #region Entidad de dominio de la imagen
    /// <summary>
    /// Entidad de dominio de la imagen
    /// </summary>    
    public class Image
        {
        /// <summary>
        /// Identificador de imagen
        /// </summary>
		public int Id { get; set; }

        /// <summary>
        /// Nombre de la imagen
        /// </summary>        
        public string ImageName { get; set; }



        /// <summary>
        /// Producto al que pertenece la imagen
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Identificador del producto al que pertenece imagen
        /// </summary>
        [ForeignKey("Product")]
        public int Product_Id { get; set; }

        } 
    #endregion
    }
