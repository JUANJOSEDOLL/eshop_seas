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
    /// Descripción breve de AdminOrderServiceList
    /// </summary>
    public class AdminOrderServiceList : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
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
            OrderManager orderManager = new OrderManager(contextdb);

            //string userId = context.User.Identity.GetUserId();

            #region select
            var allOrders = orderManager.GetTodo();
            var ordersForDataTable = allOrders
                    .Select(p => new ClientOrder
                        {
                        Id = p.Id,
                        InvoiceNumber = p.InvoiceNumber,
                        TotalInvoice = p.TotalInvoice,
                        CreatedDate = p.CreatedDate,
                        Status = p.Status.ToString(),
                        User_Id = p.User_Id,
                        });
            #endregion
            #region Filter
            if (!string.IsNullOrWhiteSpace(sSearch))
                {
                string where = @"Id.ToString().Contains(@0) ||
                                 Invoice.ToString().Contains(@0) ||
                                 TotalInvoice.ToString().Contains(@0) ||
                                 CreatedDate.ToString().Contains(@0)";

                ordersForDataTable = ordersForDataTable.Where(where, sSearch);
                }
            #endregion
            #region Paginate
            ordersForDataTable = ordersForDataTable
                        .OrderBy(sortColum + " " + iSortDir)
                        .Skip(iDisplayStart)
                        .Take(iDisplayLength);
            #endregion
            var result = new
                {
                iTotalRecords = allOrders.Count(),
                iTotalDisplayRecords = allOrders.Count(),
                aaData = ordersForDataTable
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