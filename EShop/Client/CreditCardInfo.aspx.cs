using EShop.APPLICATION;
using EShop.CORE;
using EShop.DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Net.Mail;
using System.Web;

namespace EShop.Client
    {
    public partial class Informar_tarjeta : System.Web.UI.Page, System.Web.SessionState.IReadOnlySessionState
    #region Page_Load
        {
        /// <summary>
        /// Ponemos a 0 las colecciones
        /// </summary>
        OrderManager orderManager = null;
        CartItemManager cartItemManager = null;
        OrderDetailManager orderDetailManager = null;
        ProductManager productManager = null;

        /// <summary>
        /// Se cargan los parámetros de validación de la tarjeta.
        /// Se recuperan por GET los parámetros que nos van a permitir montar los datos de order propios de esta sesión.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
            {


            //Impedimos que se pueda informa un año anterior al corriente
            txtCreditCardExpirationDateYearValidator.MinimumValue = DateTime.Now.Year.ToString();



            //Obtenemos por Identity el nombre del usuario
            txtUser.Text = User.Identity.GetUserName();

            //REcogemos por GET el total a pagar y el número de factura
            if (Request.QueryString["TotalToPay"] == null) return;
            if (Request.QueryString["Invoice"] == null) return;


            //Pintamos en la página el total a pagar y el número de factura
            lblIdentificacionTotalToPay.Text = Request.QueryString["TotalToPay"].ToString();
            lblInvoice.Text = Request.QueryString["Invoice"].ToString();

            }

        #endregion

        #region ButtonUpdateOrder_Click
        /// <summary>
        /// Este método va a insertar la linea con los datos de facturas en la tabla Orders
        /// y después llamará al método que inserta las tuplas en la tabla del detalle de órdenes
        /// al método AddOrderDetails la pasará el id de la Order así estará vinculado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void ButtonUpdateOrder_Click(object sender, EventArgs e)
            {
            try
                {
                ApplicationDbContext context = new ApplicationDbContext();
                orderManager = new OrderManager(context);

                Order order = new Order
                    {
                    InvoiceNumber = lblInvoice.Text,
                    CreatedDate = DateTime.Now,
                    Status = OrderStatus.Pendiente,
                    User_Id = User.Identity.GetUserId(),
                    TotalInvoice = float.Parse(lblIdentificacionTotalToPay.Text),
                    };

                orderManager.Add(order);
                orderManager.Context.SaveChanges();
                this.AddOrderDetails(order.Id);
                }
            catch (Exception ex)
                {
                //Identifico la página
                string errorHandler = "Error en try/catch de CreditCardInfo ButtonUpdateOrder_Click";

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

        #region AddOrderDetails
        /// <summary>
        /// Este método inserta el detalle de órdenes, sabe que artículos son porque es la colección
        /// allCartItemsOfThisSession que está formada únicamente por los artículos en el carrito
        /// de la sesión que tiene asignada el cliente en ese momento.
        /// Cuándo acabe, salvará los cambios y llamará al método StockCartItemsSelected que va a rebajar el stock.
        /// </summary>
        /// <param name="idOrder"></param>

        protected void AddOrderDetails(int idOrder)
            {
            ApplicationDbContext context = new ApplicationDbContext();
            cartItemManager = new CartItemManager(context);
            orderDetailManager = new OrderDetailManager(context);
            string sessionId = HttpContext.Current.Session.SessionID;
            var allCartItemsOfThisSession = cartItemManager.GetByCartId(sessionId);


            foreach (CartItem item in allCartItemsOfThisSession)
                {
                OrderDetail orderDetail = new OrderDetail
                    {
                    InvoiceNumber = lblInvoice.Text,
                    Product_Id = item.Product_Id,
                    Name = item.ProductName,
                    Quantity = item.Quantity,
                    Price = item.ProductPrice,
                    Order_Id = idOrder
                    };

                orderDetailManager.Add(orderDetail);

                }
            orderDetailManager.Context.SaveChanges();

            this.StockCartItemsSelected();
            }

        #endregion

        #region StockCartItemsSelected
        /// <summary>
        /// Rebaja el stock, primero llama al carrito, con la sesión lo filtra, lo recorre con un foreach,
        /// en cada loop obtiene el id del producto del carrito y se lo pasa al método DeleteById que se encargará
        /// de rebajarlo. Salva cambios, enviamos el correo al administrador y al cliente y llamamos al método DeleteOrdersInCartItemsSelected
        /// que vaciará el carrito de este cliente y para esta sesión.
        /// </summary>
        protected void StockCartItemsSelected()
            {

            ApplicationDbContext context = new ApplicationDbContext();
            cartItemManager = new CartItemManager(context);
            productManager = new ProductManager(context);

            string sessionId = HttpContext.Current.Session.SessionID;
            var allCartItemsOfThisSession = cartItemManager.GetByCartId(sessionId);


            foreach (CartItem item in allCartItemsOfThisSession)
                {

                int idProd = item.Product_Id;
                int quantity = item.Quantity;
                DeleteById(idProd, quantity);


                }
            productManager.Context.SaveChanges();

            //Enviamos el correo de confirmación al administrador y al cliente

            SendEmailToAdmin();

            SendEmailToUser();

            this.DeleteOrdersInCartItemsSelected();

            }
        #endregion

        #region DeleteById
        /// <summary>
        /// Este método va a rebajar en una unidad los productos de la tabla Products que tengan el
        /// Id que lo pasa por parámetro el método StockCartItemsSelected
        /// </summary>
        /// <param name="id"></param>
        protected void DeleteById(int id, int quantity)
            {
            try
                {
                ApplicationDbContext context = new ApplicationDbContext();

                productManager = new ProductManager(context);

                var productStck = productManager.GetById(id);

                productStck.Stock = productStck.Stock - quantity;
                }
            catch (Exception ex)
                {
                //Identifico la página
                string errorHandler = "Error en try/catch de CreditCardInfo DeleteById";

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


        #region SendEmail
        /// <summary>
        /// Este método enviará al administrador el status de su compra
        /// Los datos de configuración del email de envio se especifican en el web.config,
        /// como el email admin@admin e de desarrollo utilizo el gmail de envio
        /// </summary>
        protected void SendEmailToAdmin()
            {
            try
                {
                string recipient = txtUser.Text;

                ApplicationDbContext context = new ApplicationDbContext();
                orderManager = new OrderManager(context);
                string TotalToPay = lblIdentificacionTotalToPay.Text;
                string Invoice = lblInvoice.Text;

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
                txtBody += "<h3>Venta en nuestra EShop</h3>";
                txtBody += "<br/>";
                txtBody += "<p>A la atención de administrador,</p>";
                txtBody += "<br/>";
                txtBody += "<p>Se ha efectuado una venta en la cuenta de " + recipient + " por una cantidad de " + TotalToPay + " Euros.</p>";
                txtBody += "<br/>";
                txtBody += "<p>Se hace necesario un acceso al sistema para gestionar el pedido/factura de referencia:  " + Invoice + ".</p>";
                txtBody += "<br/>";
                txtBody += "<p>Sin otro particular,</p>";
                txtBody += "<br/>";
                txtBody += "<p><b>El sistema de ventas de EShop S.A.</b></p>";
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
                mailMessage.To.Add("joanjdoll@gmail.com");

                var smtpClient = new SmtpClient();

                smtpClient.Send(mailMessage);
                }
            catch (Exception ex)
                {
                //Identifico la página
                string errorHandler = "Error en try/catch de CreditCardInfo SendEmailToUser";

                //Creo un log a través de un método creado para ello
                //Este metodo creará un archivo de texto en la carpeta App_data
                //que genera información sobre el error y lo localiza
                ExceptionUtility.LogException(ex, errorHandler);

                //Lanza un mensaje de error al usuario
                throw new Exception("Ha habido un problema al enviar su email.");
                }
            finally
                {
                //Considero que el hecho de que el email no haya llegado al cliente no debe entorpecer 
                //la lógica de la aplicación, por lo que llamo al método que rebaja el stock
                this.DeleteOrdersInCartItemsSelected();
                }
            }


        /// <summary>
        /// Este método enviará al cliente el status de su compra
        /// Los datos de configuración del email de envio se especifican en el web.config, mientras
        /// los datos del usuario se obtienen de la página ASP.
        /// </summary>
        protected void SendEmailToUser()
            {
            try
                {
                string recipient = txtUser.Text;

                ApplicationDbContext context = new ApplicationDbContext();
                orderManager = new OrderManager(context);
                string TotalToPay = lblIdentificacionTotalToPay.Text;
                string Invoice = lblInvoice.Text;

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
                txtBody += "<p>El motivo de este correo es para informarle que hemos procedido a cargar en su tarjeta de crédito la cantidad de " + TotalToPay + " Euros en concepto de compra de su factura número: " + Invoice + ".</p>";
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
            catch (Exception ex)
                {
                //Identifico la página
                string errorHandler = "Error en try/catch de CreditCardInfo SendEmailToUser";

                //Creo un log a través de un método creado para ello
                //Este metodo creará un archivo de texto en la carpeta App_data
                //que genera información sobre el error y lo localiza
                ExceptionUtility.LogException(ex, errorHandler);

                //Lanza un mensaje de error al usuario
                throw new Exception("Ha habido un problema al enviar su email.");
                }
            finally
                {
                //Considero que el hecho de que el email no haya llegado al cliente no debe entorpecer 
                //la lógica de la aplicación, por lo que llamo al método que rebaja el stock
                this.DeleteOrdersInCartItemsSelected();
                }
            }


        #endregion

        #region DeleteOrdersInCartItemsSelected
        /// <summary>
        /// Este método vaciará el carrito de este cliente y para esta sesión, después de ello
        /// reenviará al cliente a un lista de sus facturas con la web, no se pasa el parámetro
        /// pues su detalle de facturas se filtra por identity.
        /// </summary>
        protected void DeleteOrdersInCartItemsSelected()
            {

            ApplicationDbContext context = new ApplicationDbContext();
            cartItemManager = new CartItemManager(context);

            string sessionId = HttpContext.Current.Session.SessionID;
            var allCartItemsOfThisSession = cartItemManager.GetByCartId(sessionId);


            foreach (CartItem item in allCartItemsOfThisSession)
                {

                cartItemManager.Remove(item);

                }
            cartItemManager.Context.SaveChanges();



            Response.Redirect("/Client/ClientOrderList");

            }








        #endregion

        }


    }






