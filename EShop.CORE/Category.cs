using System.Collections.Generic;

namespace EShop.CORE
    {
    #region Entidad de dominio de Categoria
    /// <summary>
    /// Entidad de dominio de Categoria
    /// </summary>    
    public class Category
        {
        /// <summary>
        /// Identificador de categoria
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre de la categoria
        /// </summary>        
        public string CategoryName { get; set; }

        /// <summary>
        /// Descripcion de la categoria
        /// </summary>        
        public string Description { get; set; }

        /// <summary>
        /// Imagen de la categoria
        /// </summary>        
        public string Image { get; set; }

        /// <summary>
        /// Colección de productos
        /// </summary>
        public virtual List<Product> Products { get; set; }
        } 
    #endregion
    }
