using EShop.CORE;
using EShop.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace EShop.Admin
    {
    public partial class SearchUser : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {

            ApplicationDbContext contextDB = new ApplicationDbContext();

            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(contextDB));

            //Llena en la primera carga de la página todos los users
            if (!IsPostBack)
                {
                var allvarUsers = userManager.Users.ToList();

                DropDownList.DataSource = allvarUsers;


                DropDownList.DataValueField = "UserName";


                DropDownList.DataTextField = "UserName";


                DropDownList.DataBind();
                }





            }

        /// <summary>
        /// Toma el item escogido y lo envia el parámetro a usar como filtro por get
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
            {
            Response.Redirect("/Admin/EditUserData?email=" + DropDownList.SelectedValue);
            }
        }
    }