using EShop.APPLICATION;
using EShop.DAL;
using System;
using System.Linq;
using System.Web;

namespace EShop.User
    {
    public partial class CartItemList : System.Web.UI.Page, System.Web.SessionState.IReadOnlySessionState
        {
        #region Page_Load
        OrderManager orderManager = null;
        CartItemManager cartItemManager = null;
        string guid = Guid.NewGuid().ToString();

        /// <summary>
        /// Al cargar la página se cargan los items del carrito
        /// Posteriormente se filtrará los items en función de la sesión actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void Page_Load(object sender, EventArgs e)
            {
            ApplicationDbContext context = new ApplicationDbContext();
            orderManager = new OrderManager(context);
            cartItemManager = new CartItemManager(context);


            //Obtenemos la sesión actual

            string sessionId = HttpContext.Current.Session.SessionID;

            //Filtramos los items del carrito con la sesión

            var allCartItemsOfThisSession = cartItemManager.GetByCartId(sessionId).Distinct();

            //Comprobamos que tenga items y obtiene la variables para conformar los datos relativos a
            //base imponible, iva y total fra, si no tiene , nos devuelve a la página productList

            if (allCartItemsOfThisSession.Count() > 0)
                {
                var totalBruto = allCartItemsOfThisSession.Sum(x => x.Quantity * x.ProductPrice);

                var totalIVA = allCartItemsOfThisSession.Sum(x => x.Quantity * x.ProductPrice * 0.21);

                var totalAPagar = allCartItemsOfThisSession.Sum(x => x.Quantity * x.ProductPrice * 1.21);

                txtBruto.Text = totalBruto.ToString("N");

                txtTotal.Text = totalIVA.ToString("N");

                txtTotalAPagar.Text = totalAPagar.ToString("N");
                }
            else
                {
                Response.Redirect("/User/ProductList");
                }
            }
        #endregion

        #region ButtonCreateOrder_Click
        /// <summary>
        /// Con este método nos redirige a la pasarela de pago
        /// Los parámetros que comparte son el total factura y el número de factura.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonCreateOrder_Click(object sender, EventArgs e)
            {
            try
                {
                //Prueba de error

                //Response.Redirect("/NoExiste/CreditCardInfo.aspx?TotalToPay=" + txtTotalAPagar.Text + "&Invoice=" + guid);

                Response.Redirect("/Client/CreditCardInfo.aspx?TotalToPay=" + txtTotalAPagar.Text + "&Invoice=" + guid);

                }
            catch (Exception ex)
                {
                //Identifico la página
                string errorHandler = "Error en try/catch de CartItemList";

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