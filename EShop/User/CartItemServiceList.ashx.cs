using EShop.APPLICATION;
using EShop.DAL;
using EShop.Models;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Script.Serialization;

namespace EShop.User
    {




    /// <summary>
    /// Descripción breve de CartItemServiceList
    /// </summary>
    public class CartItemServiceList : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
        {




        public void ProcessRequest(HttpContext context)
            {
            // Those parameters are sent by the plugin
            var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
            var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
            var sSearch = context.Request["sSearch"];
            var iSortDir = context.Request["sSortDir_0"];
            var iSortCol = context.Request["iSortCol_0"];
            var sortColum = context.Request.QueryString["mDataProp_" + iSortCol];

            //Obtenemos el vínculo al carrito contenido en la base de datos
            ApplicationDbContext contextdb = new ApplicationDbContext();
            CartItemManager cartItemManager = new CartItemManager(contextdb);

            //Obtenemos el hash de la sesión
            string sessionId = HttpContext.Current.Session.SessionID;


            #region select

            //Obtenemos los items del carrito que corresponden a esa sesión
            var allCartItemsOfThisSession = cartItemManager.GetByCartId(sessionId);

            //Esta variable contiene la colección de items y sus atributos
            var cartItems = allCartItemsOfThisSession
                    .Select(p => new CartItemModel
                        {
                        Id = p.Id,
                        CartId = p.CartId,
                        Quantity = p.Quantity,
                        ProductName = p.ProductName,
                        ProductPrice = p.ProductPrice,
                        DateCreated = p.DateCreated

                        });
            #endregion
            #region Filter
            if (!string.IsNullOrWhiteSpace(sSearch))
                {
                string where = @"Id.ToString().Contains(@0) ||
                                CartId.ToString().Contains(@0)||
                                Quantity.ToString().Contains(@0)||
                                 ProductName.ToString().Contains(@0) ||
                                 ProductPrice.ToString().Contains(@0)";

                cartItems = cartItems.Where(where, sSearch);
                }
            #endregion
            #region Paginate
            cartItems = cartItems
                        .OrderBy(sortColum + " " + iSortDir)
                        .Skip(iDisplayStart)
                        .Take(iDisplayLength);
            #endregion
            var result = new
                {
                iTotalRecords = allCartItemsOfThisSession.Count(),
                iTotalDisplayRecords = allCartItemsOfThisSession.Count(),
                aaData = cartItems
                };

            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(result);
            context.Response.ContentType = "application/json";
            context.Response.Write(json);
            }

        public bool IsReusable
            {
            get
                {
                return false;
                }
            }
        }
    }