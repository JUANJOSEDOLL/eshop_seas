using EShop.CORE;
using EShop.CORE.Contracts;
using EShop.DAL;
using System.Linq;



namespace EShop.APPLICATION
    {
    /// <summary>
    /// Clase manager de Imágenes
    /// </summary>
    public class ImageManager : GenericManager<Image>, IImageManager
        {
        /// <summary>
        /// Constructor de interfacee la clase Manager de Image
        /// </summary>
        /// <param name="context">Contexto de datos de interface</param>
        public ImageManager(IApplicationDbContext context) : base(context)
            {
            }


        /// <summary>
        /// Constructor de la clase Manager de Imagen
        /// </summary>
        /// <param name="context">Contexto de datos</param>
        public ImageManager(ApplicationDbContext context) : base(context)
            {
            }

        /// <summary>
        /// Método que retorna todas los Imagenes
        /// </summary>

        public IQueryable<Image> GetTodos()
            {
            return Context.Set<Image>();
            }

        /// <summary>
        /// Método que retorna todas las Imagenes de un producto
        /// </summary>
        /// <param name="ProductId">Identificador de producto</param>
        /// <returns>Todos las Imagenes de una imagen </returns>
        public IQueryable<Image> GetByProductId(int ProductId)
            {
            return Context.Set<Image>().Where(e => e.Product_Id == ProductId);
            }

       



        }
    }

