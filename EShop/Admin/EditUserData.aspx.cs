using EShop.DAL;
using EShop.APPLICATION;
using EShop.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using EShop.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Routing;
using System.Web.Optimization;

namespace EShop.Admin
    {
    public partial class EditUserData : System.Web.UI.Page
        {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
            {

            ApplicationDbContext context = new ApplicationDbContext();

            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (Request.QueryString["email"] == null) return;

            var userEmail = Request.QueryString["email"].ToString();

            ApplicationUser user = userManager.FindByEmail(userEmail);

            if (user != null)
                {
                if (!Page.IsPostBack)
                    LoadClientData(user);
                }

            }
        #endregion





        #region LoadClientData
        ///// <summary>
        /// Método que carga los datos del cliente parametrizado 
        /// 
        /// </summary>
        /// <param name="useremail"></param>
        private void LoadClientData(ApplicationUser user)
            {
            try
                {



                Email.Text = user.Email.ToString();
                txtFirstName.Text = user.FirstName.ToString();
                txtLastName.Text = user.LastName.ToString();
                txtAddress.Text = user.Address.ToString();
                txtPostalCode.Text = user.PostalCode.ToString();
                txtCity.Text = user.City.ToString();
                txtProvince.Text = user.Province.ToString();
                txtCountry.Text = user.Country.ToString();
                txtCif_Nif.Text = user.Cif_Nif.ToString();
                txtPhone.Text = user.Phone.ToString();
                }
            catch (Exception ex)
                {
                //Identifico la página
                string errorHandler = "Error en try/catch de EditUserData en admin";

                //Creo un log a través de un método creado para ello
                //Este metodo creará un archivo de texto en la carpeta App_data
                //que genera información sobre el error y lo localiza
                ExceptionUtility.LogException(ex, errorHandler);

                //Una vez generado registro redirige al usuario hacia una página de error
                //pero en ningún caso da mensajes por pantalla que puedan afectar a la seguridad del sitio
                Server.Transfer("/ErrorPages/Oops.aspx?handler=Application_Error%20-%20Global.asax", true);
                }


            }

        protected void UpdateUserToAdmin_Click(object sender, EventArgs e)
            {


            try
                {
                ApplicationDbContext context = new ApplicationDbContext();

                RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


                ApplicationUser user = userManager.FindByName(Email.Text);

                if (user == null)
                    {

                    throw new Exception("Usuario no existe");

                    }
                else
                    {
                    //El usuario está creado, ¿Pero ya esta en el rol admin?
                    if (!userManager.IsInRole(user.Id, "Admin"))
                        {
                        userManager.AddToRole(user.Id, "Admin");
                        }
                    }
                }
            catch (Exception ex)
                {

                //Identifico la página
                string errorHandler = "Error en try/catch de EditUserData en admin";

                //Creo un log a través de un método creado para ello
                //Este metodo creará un archivo de texto en la carpeta App_data
                //que genera información sobre el error y lo localiza
                ExceptionUtility.LogException(ex, errorHandler);

                //Una vez generado registro redirige al usuario hacia una página de error
                //pero en ningún caso da mensajes por pantalla que puedan afectar a la seguridad del sitio
                Server.Transfer("/ErrorPages/Oops.aspx?handler=Application_Error%20-%20Global.asax", true);
                }

            }



        #endregion

        #region UpdateUser_Click
        /// <summary>
        /// Este método actualizará los datos del cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UpdateUser_Click(object sender, EventArgs e)
            {

            ApplicationDbContext context = new ApplicationDbContext();

            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            ApplicationUser user = userManager.FindByEmail(Email.Text);



            user.Address = txtAddress.Text;
            user.City = txtCity.Text;
            user.Country = txtCountry.Text;
            user.FirstName = txtFirstName.Text;
            user.LastName = txtLastName.Text;
            user.Phone = txtPhone.Text;
            user.PostalCode = txtPostalCode.Text;
            user.Province = txtProvince.Text;
            user.Cif_Nif = txtCif_Nif.Text;

            //A diferencia de el resto de entidades, este manager no emplea la función
            //SaveChanges() de Context sino la propia de la clase Usermanager: Update(object)
            userManager.Update(user);


            } 
        #endregion


        }
    }