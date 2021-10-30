using EShop.APPLICATION;
using EShop.CORE;
using EShop.DAL;
using System;

namespace EShop.Admin
    {
    public partial class CreateFormCategory : System.Web.UI.Page
        {
        #region         protected void Page_Load(object sender, EventArgs e)

        CategoryManager categoryManager = null;

        /// <summary>
        /// Con la carga de la página se inicia un objeto categoryManager
        /// que permitirá interactuar con el contexto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
            {
            ApplicationDbContext context = new ApplicationDbContext();
            categoryManager = new CategoryManager(context);

            }

        /// <summary>
        /// Método que responde al evento clic del botón
        /// Su ejecución persistirá el objeto category con los atributos recogidos
        /// en la aspx, generando una tupla en la tabla category del sql server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        #endregion
        #region BtnSubmit_Click
        protected void BtnSubmit_Click(object sender, EventArgs e)
            {
            try
                {
                Category category = new Category

                    {

                    CategoryName = txtCategoryName.Text,
                    Description = txtDescription.Text,
                    Image = "noImageAvailable.jpg"


                    };

                //Añade el objeto al manager
                categoryManager.Add(category);

                //Lo inserta en la tupla
                categoryManager.Context.SaveChanges();

                //Borra los textbox del formulario
                txtCategoryName.Text = string.Empty;
                txtDescription.Text = string.Empty;

                }
            catch (Exception ex)
                {
                //Identifico la página
                string errorHandler = "Error en try/catch de CreateFormCategory";

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