using EShop.CORE;
using EShop.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Script.Serialization;

namespace EShop.Admin
    {
    /// <summary>
    /// Descripción breve de UserServiceList
    /// </summary>
    public class UserServiceList : IHttpHandler
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


            ApplicationDbContext contextDB = new ApplicationDbContext();

            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(contextDB));



            #region select
            var allvarUsers = userManager.Users.ToList();


            var varUsers = allvarUsers
                    .Select(p => new ApplicationUser
                        {
                        FirstName = p.FirstName,

                        LastName = p.LastName
                        });
            #endregion
            #region Filter
            if (!string.IsNullOrWhiteSpace(sSearch))
                {
                string where = @"Id.ToString().Contains(@0) ||
                                 UserName.ToString().Contains(@0)";

                varUsers = varUsers.Where(where, sSearch);
                }
            #endregion
            #region Paginate
            varUsers = varUsers
                        .OrderBy(sortColum + " " + iSortDir)
                        .Skip(iDisplayStart)
                        .Take(iDisplayLength);
            #endregion
            var result = new
                {
                iTotalRecords = allvarUsers.Count(),
                iTotalDisplayRecords = allvarUsers.Count(),
                aaData = varUsers
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