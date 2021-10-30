using EShop.APPLICATION;
using EShop.CORE;
using EShop.DAL;
using System;
using System.Web.UI;

namespace EShop.Admin
    {
    public partial class EditFormCategory : System.Web.UI.Page
        {


        #region Page_Load
        CategoryManager categoryManager = null;

        /// <summary>
        /// Carga la categoria en función del id pasado por http get
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
                            LoadCategory(category);
                        }
                    }
                }
            }

        /// <summary>
        /// Obtiene los atributos del objeto categoria cargado
        /// para poder mostrarlos en el front-end aspx
        /// </summary>
        /// <param name="category"></param>
        private void LoadCategory(Category category)
            {
            txtId.Value = category.Id.ToString();
            txtEditCategoryName.Text = category.CategoryName;
            txtEditDescription.Text = category.Description;

            }
        #endregion


        #region Page_Load
        /// <summary>
        /// Persiste los cambios en el objeto categoría cargado previamente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSubmit_Click(object sender, EventArgs e)
            {
            try
                {

                var category = categoryManager.GetById(int.Parse(txtId.Value));

                category.CategoryName = txtEditCategoryName.Text;
                category.Description = txtEditDescription.Text;

                categoryManager.Context.SaveChanges();

                Response.Redirect("/Admin/CategoryList");

                }
            catch (Exception ex)
                {
                //Identifico la página
                string errorHandler = "Error en try/catch de EditFormCategory";

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



