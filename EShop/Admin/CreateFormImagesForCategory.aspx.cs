using EShop.APPLICATION;
using EShop.CORE;
using EShop.DAL;
using System;
using System.Web.UI;
//using Image = EShop.CORE.Image;

namespace EShop.Admin
    {
    public partial class CreateFormImagesForCategory : System.Web.UI.Page
        {
        #region Page_Load
        CategoryManager categoryManager = null;
        string guid = Guid.NewGuid().ToString();


      
        /// <summary>
        /// Recoge por http get el id de la categoría
        /// obtiene el objeto y lo pasa por parámetro a
        /// al método LoadCategory
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
        /// Pinta la id de la categoría para emplearla como
        /// parámetro al cargar la imagen
        /// </summary>
        /// <param name="category"></param>
        private void LoadCategory(Category category)
            {
            txtId.Value = category.Id.ToString();


            }

        #endregion
        
        #region BtnSubmit_Click

        /// <summary>
        /// Carga la imagen seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSubmit_Click(object sender, EventArgs e)
            {
            try
                {
                Label1.Text = "";

                //Si hay archivo lo carga
                if (FileUpload2.HasFile)
                    {
                    string extension = System.IO.Path.GetExtension(FileUpload2.FileName);

                    //Comprueba que tenga la extensión aceptada
                    if (extension == ".jpg" || extension == ".png" || extension == ".gif")
                        {
                        //Guarda la ubicación del archivo
                        string path = Server.MapPath("~\\Content\\Images\\");

                        //Le da un nombre unívoco gracias a guid
                        string image = guid + FileUpload2.FileName;

                        //Salva el nombre con la ubicación
                        FileUpload2.SaveAs(path + image);

                        //Crea el objeto con su nombre y le asigna la id de su categoria
                        Category category = new Category

                            {
                            Image = image,
                            Id = int.Parse(txtId.Value)
                            };

                        //Persiste el objeto
                        categoryManager.Add(category);
                        categoryManager.Context.SaveChanges();



                        //Mensaje si todo ha ido bien
                        Label1.Text = "Imagen guardada";
                        }
                    else
                        {
                        //Mensaje si se ha escogido un archivo que no es una imagen válida
                        Label1.Text = "La imagen ha de tener extensión jpg, png o gif";
                        }

                    }
                else
                    {
                    //mensaje si se pulsa guardar sin haber escogido ningún archivo de imagen
                    Label1.Text = "Por favor selecciona una imagen";
                    }

                }

            catch (Exception ex)
                {
                //Identifico la página
                string errorHandler = "Error en try/catch de CreateFormImagesForCategory";

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