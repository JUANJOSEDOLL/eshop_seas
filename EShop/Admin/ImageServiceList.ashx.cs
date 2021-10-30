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
    /// Descripción breve de ImageServiceList
    /// </summary>
    public class ImageServiceList : IHttpHandler
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
            ImageManager imageManager = new ImageManager(contextdb);

            #region select
            var allImages = imageManager.GetAll();
            var images = allImages
                .Select(p => new AdminImageList
                    {
                    Id = p.Id,
                    ImageName = p.ImageName,
                    Product_Id = p.Product_Id

                    });
            #endregion
            #region Filter
            if (!string.IsNullOrWhiteSpace(sSearch))
                {
                string where = @"Id.ToString().Contains(@0) ||
                                 ImageName.ToString().Contains(@0) ||
                                 Product_Id.ToString().Contains(@0)";
                images = images.Where(where, sSearch);
                }
            #endregion
            #region Paginate
            images = images
                         .OrderBy(sortColum + " " + iSortDir)
                        .Skip(iDisplayStart)
                        .Take(iDisplayLength);
            #endregion
            var result = new
                {
                iTotalRecords = allImages.Count(),
                iTotalDisplayRecords = allImages.Count(),
                aaData = images
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