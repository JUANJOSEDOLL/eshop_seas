using EShop.APPLICATION;
using EShop.CORE;
using EShop.DAL;
using System;
using System.Web.UI;


namespace EShop.Admin
    {
    public partial class DeleteRowCategory : System.Web.UI.Page
        {

        #region Page_Load
        CategoryManager categoryManager = null;




        /// <summary>
        /// Recoge por http get el id de la categoría
        /// obtiene el objeto y lo pasa por parámetro a
        /// al método DeleteCategory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
            {
            ApplicationDbContext context = new ApplicationDbContext();
            categoryManager = new CategoryManager(context);


            int id = 0;
            if (Request.QueryString["id"] != null)
                {
                if (int.TryParse(Request.QueryString["id"], out id))
                    {
                    var category = categoryManager.GetById(id);
                    if (category != null)
                        {
                        if (!Page.IsPostBack)
                            DeleteCategory(category);
                        }
                    }
                }
            }
        /// <summary>
        /// Borra el objeto categoría pasado como parámetro de método
        /// </summary>
        /// <param name="product"></param>
        private void DeleteCategory(Category category)
            {
            try
                {
                categoryManager.Remove(category);
                categoryManager.Context.SaveChanges();
                Response.Redirect("CategoryList");

                }
            catch (Exception ex)
                {
                //Identifico la página
                string errorHandler = "Error en try/catch de DeleteRowCategory";

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