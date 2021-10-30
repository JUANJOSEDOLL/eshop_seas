using EShop.APPLICATION;
using EShop.DAL;
using System;
using System.Web.UI;
using Image = EShop.CORE.Image;

namespace EShop.Admin
    {
    public partial class DeleteRowImage : System.Web.UI.Page
        {

        #region Page_Load
        ImageManager imageManager = null;


        /// <summary>
        /// Recoge por http get el id de la imagen
        /// obtiene el objeto y lo pasa por parámetro a
        /// al método DeleteImage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void Page_Load(object sender, EventArgs e)
            {
            ApplicationDbContext context = new ApplicationDbContext();
            imageManager = new ImageManager(context);


            int id = 0;
            if (Request.QueryString["id"] != null)
                {
                if (int.TryParse(Request.QueryString["id"], out id))
                    {
                    var image = imageManager.GetById(id);
                    if (image != null)
                        {
                        if (!Page.IsPostBack)
                            DeleteImage(image);
                        }
                    }
                }
            }

        /// <summary>
        /// Borra el objeto image pasado como parámetro de método
        /// </summary>
        /// <param name="product"></param>
        private void DeleteImage(Image image)
            {
            try
                {
                imageManager.Remove(image);
                imageManager.Context.SaveChanges();
                Response.Redirect("ImageList");

                }
            catch (Exception ex)
                {
                //Identifico la página
                string errorHandler = "Error en try/catch de DeleteRowImage";


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