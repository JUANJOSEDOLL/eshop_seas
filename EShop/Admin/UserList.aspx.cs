using EShop.CORE;
using EShop.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;

namespace EShop.Admin
    {
    public partial class UserList : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {

            ApplicationDbContext contextDB = new ApplicationDbContext();

            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(contextDB));



            var allvarUsers = userManager.Users.ToList();

            DropDownList2.DataSource = allvarUsers;


            DropDownList2.DataValueField = "LastName";


            DropDownList2.DataTextField = "UserName";


            DropDownList2.DataBind();


           

            Select1.DataSource = allvarUsers;
            Select1.DataTextField = "UserName";
            Select1.DataValueField = "UserName";
            Select1.DataBind();

            }





        }
    }