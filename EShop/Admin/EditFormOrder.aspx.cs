using EShop.APPLICATION;
using EShop.CORE;
using EShop.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Net.Mail;
using System.Web.UI;


namespace EShop.Admin
    {
    public partial class EditFormOrder : System.Web.UI.Page, System.Web.SessionState.IReadOnlySessionState
        {


        #region Page_Load
        OrderManager orderManager = null;


        /// <summary>
        /// La carga de la página nos va a llevar a cabo dos acciones:
        /// Cargar la situación de la orden, el id del cliente y el 
        /// enumerado del status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
            {

            ApplicationDbContext context = new ApplicationDbContext();
            orderManager = new OrderManager(context);


            //Llenamos una vez, el dropdownlist del enumerado del status de la orden
            if (!Page.IsPostBack)
                {
                ddlType.DataSource = Enum.GetValues(typeof(OrderStatus));
                ddlType.DataBind();

                }



            //Recogemos por get la id pasada de producto desde el list anterior
            int id = 0;
            if (Request.QueryString["id"] != null)
                {
                if (int.TryParse(Request.QueryString["id"], out id))
                    {
                    var order = orderManager.GetById(id);
                    if (order != null)
                        {
                        if (!Page.IsPostBack)
                            LoadOrder(order);
                        }
                    }
                }
            }
        #endregion


        #region LoadOrder
        /// <summary>
        /// Este método carga la orden para obtener los datos necesarios para el
        /// cambio del status y el envio del correo al cliente con la modificación.
        /// </summary>
        /// <param name="order"></param>
        private void LoadOrder(Order order)
            {

            txtId.Value = order.Id.ToString();

            ddlTypeText.Text = order.Status.ToString();

            lblUser_Id.Value = order.User_Id.ToString();

            LoadEmail();

            }
        #endregion

        #region LoadEmail
        /// <summary>
        /// Este método va ha obtener el email del cliente a partir del user_id
        /// que se encuentra como propiedad de la orden
        /// Se emplea la clase UserManager para acceder desde aquí  al contexto del user.
        /// </summary>
        private void LoadEmail()
            {
            ApplicationDbContext context = new ApplicationDbContext();

            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            ApplicationUser user = userManager.FindById(lblUser_Id.Value);

            var emailUser = user.Email;

            txtEmailUser.Text = emailUser.ToString();

            }


        /// <summary>
        /// Con este método vamos a llevar a cabo tres acciones:
        /// Cambio de status en función de la selección del dropdown
        /// Envio del email al cliente
        /// Volvemos al listado de gestión de las órdenes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        #endregion
        #region SendEmailToUseryRegion
        protected void BtnSubmit_Click_Order(object sender, EventArgs e)
            {
            try
                {

                var order = orderManager.GetById(int.Parse(txtId.Value));
                order.Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), ddlType.SelectedValue);
                orderManager.Context.SaveChanges();

                SendEmailToUser();
                Response.Redirect("/Admin/AdminOrderList");

                }
            catch (Exception ex)
                {
                //Identifico la página
                string errorHandler = "Error en try/catch de EditformOrder";

                //Creo un log a través de un método creado para ello
                //Este metodo creará un archivo de texto en la carpeta App_data
                //que genera información sobre el error y lo localiza
                ExceptionUtility.LogException(ex, errorHandler);

                //Una vez generado registro redirige al usuario hacia una página de error
                //pero en ningún caso da mensajes por pantalla que puedan afectar a la seguridad del sitio
                Server.Transfer("/ErrorPages/Oops.aspx?handler=Application_Error%20-%20Global.asax", true);
                }


            } 
        


        /// <summary>
        /// Este método enviará al cliente actualización de su compra
        /// Los datos de configuración del email de envio se especifican en el web.config, mientras
        /// los datos del usuario se obtienen de la página ASP.
        /// </summary>
        protected void SendEmailToUser()
            {
            try
                {
                string recipient = txtEmailUser.Text;
                string statusOrder = ddlType.SelectedValue;

                ApplicationDbContext context = new ApplicationDbContext();
                orderManager = new OrderManager(context);


                string txtBody = "<!DOCTYPE html>";
                txtBody += "<html lang='es'>";
                txtBody += "<head>";
                txtBody += "<meta charset='utf - 8'>";
                txtBody += "<title>Compra en nuestra EShop</title>";

                txtBody += "<style>";
                txtBody += "div {text - align: justify; text - justify: inter - word;}";

                txtBody += " </style>";

                txtBody += "</head>";
                txtBody += "<body>";
                txtBody += "<h3>Compra en nuestra EShop</h3>";
                txtBody += "<br/>";
                txtBody += "<p>A la atención de " + recipient + ",</p>";
                txtBody += "<br/>";
                txtBody += "<p>El motivo de este correo es para informarle que hemos procedido a actualizar la situación de su pedido a " + statusOrder + ".</p>";
                txtBody += "<br/>";
                txtBody += "<p>Para cualquier duda sobre este email, rogamos contacten con nuestra web en la dirección: <a>www.eshop.com</a></p>";
                txtBody += "<br/>";
                txtBody += "<p>Sin otro particular,</p>";
                txtBody += "<br/>";
                txtBody += "<p><b>El equipo de ventas de EShop S.A.</b></p>";
                txtBody += "<div>";
                txtBody += "<p>Puedes gestionar tu consentimiento de forma personalizada en tu área de usuario <a href='www.eshop.com'>clicando aquí.</a></p>";
                txtBody += "<p>Puedes consultar y ejercer tus derechos, así como consultar las bases legitimadoras del tratamiento de tus datos en nuestra política de privacidad</p>";
                txtBody += "<p>En cumplimiento de la normativa vigente en materia de protección de datos personales y en base a nuestra Política de Privacidad (disponible aquí), </p>";
                txtBody += "<p>la cual Vd.ha leído y aceptado previamente al envío de la presente comunicación, le informamos que los datos personales que nos has facilitado</p>";
                txtBody += "<p>serán tratados por EShop, S.A. como responsable de su tratamiento, con la finalidad principal de enviarte comunicaciones comerciales</p>";
                txtBody += "<p>para informarte de productos, novedades, promociones y beneficios exclusivos para ti, o bien para realizar encuestas de satisfacción</p>";
                txtBody += "<p>rectificación y cancelación de los datos, u oponerse al tratamiento de los mismos, así como otros derechos, mediante el envío de una carta dirigida</p>";
                txtBody += "<p> a c/ Programador, 15 - 08001 Barcelona o correo electrónico a la dirección admin@eshop.com</p>";
                txtBody += "<div/>";
                txtBody += "</body>";


                var mailMessage = new MailMessage
                    {
                    From = new MailAddress("joanjdoll@gmail.com"),
                    Subject = "Comunicación de su pedido en nuestra EShop",
                    Body = txtBody,
                    IsBodyHtml = true,
                    };
                mailMessage.To.Add(recipient);

                var smtpClient = new SmtpClient();

                smtpClient.Send(mailMessage);
                }

            catch (System.Net.Mail.SmtpException ex)
                {
                //Identifico la página
                string errorHandler = "Error en try/catch de EditFormOrderSendEmailToUser()";

                //Creo un log a través de un método creado para ello
                //Este metodo creará un archivo de texto en la carpeta App_data
                //que genera información sobre el error y lo localiza
                ExceptionUtility.LogException(ex, errorHandler);

                //Una vez generado registro redirige al usuario hacia una página de error
                //pero en ningún caso da mensajes por pantalla que puedan afectar a la seguridad del sitio
                Server.Transfer("/ErrorPages/Oops.aspx?handler=Application_Error%20-%20Global.asax", true);
                }
            finally
                {
                Response.Redirect("../Default.aspx");
                }
            }
        #endregion
        }
    }




