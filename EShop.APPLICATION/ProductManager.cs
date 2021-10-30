using EShop.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.DAL;
using EShop.CORE.Contracts;

namespace EShop.APPLICATION
    {
    /// <summary>
    /// Clase manager de Product
    /// </summary>
    public class ProductManager : GenericManager<Product> , IProductManager
        {
        /// <summary>
        /// Constructor de la clase Manager de Producto
        /// </summary>
        /// <param name="context">Contexto de datos</param>
        public ProductManager(IApplicationDbContext context) : base(context)
            {
            }


        /// <summary>
        /// Método que retorna todos los productos
        /// </summary>

        public IQueryable<Product> GetTodos()
            {
            return Context.Set<Product>();
            }

        /// <summary>
        /// Método que retorna todos los productos de una categoria
        /// </summary>
        /// <param name="CategoryId">Identificador de Category</param>
        /// <returns>Todos los productos de una categoria </returns>
        public IQueryable<Product> GetByCategoryId(int CategoryId)
            {
            return Context.Set<Product>().Where(e => e.Category_Id == CategoryId);
            }

        /// <summary>
        /// Obtiene las imagenes de un producto
        /// </summary>
        /// <param name="id">Identificador del producto</param>
        /// <returns>Producto con sus imágenes si existe o null en caso de no existir</returns>
        public Product GetByIdAndImage(int id)
            {
            return Context.Set<Product>().Include("Images").Where(i => i.Id == id).SingleOrDefault();
            }



        }
    }
