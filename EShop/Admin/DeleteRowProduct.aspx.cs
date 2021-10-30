using EShop.APPLICATION;
using EShop.CORE;
using EShop.DAL;
using System;
using System.Web.UI;


namespace EShop.Admin
    {
    public partial class DeleteRowProduct : System.Web.UI.Page
        {

        #region Page_Load
        ProductManager productManager = null;




        /// <summary>
        /// Carga el producto pasado por get y capturado por QueryString
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
            {
            ApplicationDbContext context = new ApplicationDbContext();
            productManager = new ProductManager(context);


            int id = 0;
            if (Request.QueryString["id"] != null)
                {
                if (int.TryParse(Request.QueryString["id"], out id))
                    {
                    var product = productManager.GetById(id);
                    if (product != null)
                        {
                        if (!Page.IsPostBack)
                            DeleteProduct(product);
                        }
                    }
                }
            }
        #endregion

        #region DeleteProduct
        /// <summary>
        /// Borra el objeto producto pasado como parámetro
        /// </summary>
        /// <param name="product"></param>
        private void DeleteProduct(Product product)
            {
            try
                {
                productManager.Remove(product);
                productManager.Context.SaveChanges();
                Response.Redirect("ProductListAdmin");
                }
            catch (Exception ex)
                {
                //Identifico la página
                string errorHandler = "Error en try/catch de DeleteRowProduct";

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