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
    /// Descripción breve de CategoryServiceList
    /// </summary>
    public class CategoryServiceList : IHttpHandler
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
            CategoryManager categoryManager = new CategoryManager(contextdb);

            #region select
            var allcategories = categoryManager.GetAll();
            var categories = allcategories
                    .Select(p => new AdminCategoryList
                        {
                        Id = p.Id,
                        CategoryName = p.CategoryName,
                        Description = p.Description,

                        });
            #endregion
            #region Filter
            if (!string.IsNullOrWhiteSpace(sSearch))
                {
                string where = @"Id.ToString().Contains(@0) ||
                                 CategoryName.ToString().Contains(@0) ||
                                 Description.ToString().Contains(@0)";

                categories = categories.Where(where, sSearch);
                }
            #endregion
            #region Paginate
            categories = categories
                        .OrderBy(sortColum + " " + iSortDir)
                        .Skip(iDisplayStart)
                        .Take(iDisplayLength);
            #endregion
            var result = new
                {
                iTotalRecords = allcategories.Count(),
                iTotalDisplayRecords = allcategories.Count(),
                aaData = categories
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