using EShop.CORE;
using EShop.CORE.Contracts;
using EShop.DAL;

namespace EShop.APPLICATION
    {
    /// <summary>
    /// Clase manager de OrderDetailManager
    /// </summary>
    public class OrderDetailManager : GenericManager<OrderDetail>, IOrderDetailManager
        {

        /// <summary>
        /// Constructor de interface la clase Manager de OrderDetailManager
        /// </summary>
        /// <param name="context">Contexto de datos de interface</param>
        public OrderDetailManager(IApplicationDbContext context) : base(context)
            {
            }

        /// <summary>
        /// Constructor de la clase Manager de OrderDetail
        /// </summary>
        /// <param name="context">Contexto de datos</param>
        /// 

        public OrderDetailManager(ApplicationDbContext context) : base(context)
            {
            }


        }
    }
