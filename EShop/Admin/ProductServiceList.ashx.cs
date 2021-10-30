using EShop.APPLICATION;
using EShop.DAL;
using EShop.Models;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Script.Serialization;

namespace EShop.Admin
    {
    /// <summary>
    /// Descripción breve de ProductServiceList
    /// </summary>
    public class ProductServiceList : IHttpHandler
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


            ApplicationDbContext contextdb = new ApplicationDbContext();
            ProductManager productManager = new ProductManager(contextdb);

            #region select
            var allProducts = productManager.GetAll();
            var products = allProducts
                    .Select(p => new AdminProductList
                        {
                        Id = p.Id,
                        ProductName = p.ProductName,
                        ProductDescription = p.ProductDescription,
                        ProductPrice = p.ProductPrice,
                        Stock = p.Stock
                        });
            #endregion
            #region Filter
            if (!string.IsNullOrWhiteSpace(sSearch))
                {
                string where = @"Id.ToString().Contains(@0) ||
                                 ProductName.ToString().Contains(@0) ||
                                 ProductDescription.ToString().Contains(@0) ||
                                 ProductPrice.ToString().Contains(@0) ||
                                 Stock.ToString().Contains(@0)";
                products = products.Where(where, sSearch);
                }
            #endregion
            #region Paginate
            products = products
                        .OrderBy(sortColum + " " + iSortDir)
                        .Skip(iDisplayStart)
                        .Take(iDisplayLength);
            #endregion
            var result = new
                {
                iTotalRecords = allProducts.Count(),
                iTotalDisplayRecords = allProducts.Count(),
                aaData = products
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