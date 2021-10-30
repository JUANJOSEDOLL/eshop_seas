using EShop.APPLICATION;
using EShop.CORE;
using EShop.DAL;
using System;
using System.Collections.Generic;


namespace EShop.Admin
    {
    public partial class CreateFormOrder : System.Web.UI.Page
        {
        #region Page_Load
        OrderManager orderManager = null;

        public OrderStatus orderStatus = 0;

        /// <summary>
        /// Con la carga de la página se inicia el manager de order 
        /// y una instancia de status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
            {
            ApplicationDbContext context = new ApplicationDbContext();
            orderManager = new OrderManager(context);
            orderStatus = new OrderStatus();


            }
        #endregion

        #region BtnSubmit_Click
        /// <summary>
        /// El evento clic del front end arrancará la persistencia
        /// de la orden y una linea de detalle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSubmit_Click(object sender, EventArgs e)
            {
            try
                {
                Order order = new Order
                    {

                    CreatedDate = DateTime.Now,
                    Status = OrderStatus.Pendiente,
                    User_Id = txtUser_Id.Text,
                    OrderDetails = new List<OrderDetail>
                {
                    new OrderDetail
                    {
                         Product_Id=int.Parse(txtIdProducto.Text),
                         Name=txtName.Text,
                         Quantity=int.Parse(txtCantidad.Text),
                         Price=float.Parse(txtPrecio.Text),



                    }
                }

                    };

                //Persistencia de la orden
                orderManager.Add(order);
                orderManager.Context.SaveChanges();

                }
            catch (Exception ex)
                {
                //Identifico la página
                string errorHandler = "Error en try/catch de CreateFormOrder";

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