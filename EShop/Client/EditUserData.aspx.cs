using EShop.CORE;
using EShop.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace EShop.Client
    {
    public partial class EditUserData : System.Web.UI.Page
        {

        #region carga los datos del cliente
        protected void Page_Load(object sender, EventArgs e)
            {

            // Obtenemos la sesión que nos permitirá obtener su id

            string userId = User.Identity.GetUserId();

            HiddenField1.Value = userId;


            //Llamamos al método que nos permitirá obtener los datos del usuario titular
            //de la factura

            if (!IsPostBack)
                LoadClientData(userId);


            }


        /// <summary>
        /// Método que  parametrizado en función del ID de cliente 
        /// de la sesión
        /// </summary>
        /// <param name="userId"></param>
        private void LoadClientData(string userId)
            {
            try
                {
                ApplicationDbContext context = new ApplicationDbContext();

                UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                ApplicationUser user = userManager.FindById(userId);

                //llenamos las textBox que corresponden a la tabla cliente

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
                string errorHandler = "Error en try/catch de EditUserData";

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

            ApplicationUser user = userManager.FindById(HiddenField1.Value);



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