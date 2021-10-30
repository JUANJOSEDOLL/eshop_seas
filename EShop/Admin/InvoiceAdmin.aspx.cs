using EShop.APPLICATION;
using EShop.CORE;
using EShop.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;

namespace EShop.Admin
    {
    public partial class InvoiceAdmin : System.Web.UI.Page
        {
        #region Carga de los datos de la factura pasados desde AdminOrderList
        protected void Page_Load(object sender, EventArgs e)
            {



            //Con el id pasado por parámetro de la order, obtendremos sus datos y 
            //los de las lineas de detalle
            //El area admin es restringida al administrador, no es necesario hacer una verificación
            //de id de user pues el único user que tiene acceso es el administrador


            int id = 0;
            if (Request.QueryString["id"] != null)
                {
                if (int.TryParse(Request.QueryString["id"], out id)) ;
                }



            //Obtenemos los datos de la tabla orders
            //filtrado con el parámetro pasado por GET



            ApplicationDbContext contextDB = new ApplicationDbContext();
            OrderManager orderManager = new OrderManager(contextDB);
            OrderDetailManager orderDetailManager = new OrderDetailManager(contextDB);

            //Obtenemos la colección de detalle para la orden de identificador recogido en id
            var orderFilteredById = orderManager.GetById(id).OrderDetails;

            //Obtenemos los parámetros de cabecera de la factura

            //El número de factura
            string fra = orderManager.GetById(id).InvoiceNumber;

            //El número de pedido
            int ord = orderManager.GetById(id).Id;

            //La fecha de la factura
            DateTime dateFRA = orderManager.GetById(id).CreatedDate;

            //Asignamos los diferentes datos al ASPX para poder pintarlos
            txtFRA.Text = fra;
            txtOrder.Text = ord.ToString();
            txtDate.Text = dateFRA.ToString("dd-MM-yyyy");



            //llenamos el datagrid con la colección de items del detalle de la orden

            GridView1.DataSource = orderFilteredById;
            GridView1.DataBind();

            //En lugar de calcular sobre los datos del gridView
            //accedemos al total factura los datos del detalle de ordenes
            //Existen fórmulas para plasmarlo en la propia ASPX, sin embargo
            //intento minimizar la lógica en el front-end

            var totalBruto = orderFilteredById.Sum(x => x.Quantity * x.Price);

            var totalIVA = orderFilteredById.Sum(x => x.Quantity * x.Price * 0.21);

            var totalAPagar = orderFilteredById.Sum(x => x.Quantity * x.Price * 1.21);

            txtBruto.Text = totalBruto.ToString("N");

            txtTotal.Text = totalIVA.ToString("N");

            txtTotalAPagar.Text = totalAPagar.ToString("N");

            //Obtenemos el Id_user que se encuentra en el objeto Order
            string userId = orderManager.GetById(id).User_Id;

            //Llamamos al método que nos permitirá obtener los datos del usuario titular
            //de la factura
            LoadClientData(userId);


            }
        #endregion


        #region Carga los datos del cliente
        /// <summary>
        /// Método que carga los datos del cliente parametrizado en función del ID de cliente contenido
        /// en el objeto order.
        /// </summary>
        /// <param name="userId"></param>
        private void LoadClientData(string userId)
            {
            try
                {
                ApplicationDbContext context = new ApplicationDbContext();

                UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                ApplicationUser user = userManager.FindById(userId);

                //llenamos las labels que corresponden a la tabla cliente

                txtFirstNameLabel.Text = user.FirstName.ToString();
                txtLastNameLabel.Text = user.LastName.ToString();
                txtCif_NifLabel.Text = user.Cif_Nif.ToString();
                txtPhoneLabel.Text = user.Phone.ToString();
                txtEmailLabel.Text = user.Email.ToString();

                var oneLineAddress = user.Address.ToString() + " " + user.PostalCode.ToString() + "-" + user.City.ToString() + " " + user.Province.ToString() + " (" + user.Country.ToString() + ") ";
                txtOneLineAddress.Text = oneLineAddress;
                }
            catch (Exception ex)
                {
                //Identifico la página
                string errorHandler = "Error en try/catch de InvoiceAdmin";

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
        }
    }