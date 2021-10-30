using EShop.APPLICATION;
using EShop.CORE;
using EShop.DAL;
using System;
using System.Web.UI;
using Image = EShop.CORE.Image;

namespace EShop.Admin
    {
    public partial class CreateFormImages : System.Web.UI.Page
        {
        #region Page_Load
        ProductManager productManager = null;
        ImageManager imageManager = null;
        string guid = Guid.NewGuid().ToString();


        /// <summary>
        /// Con la carga de la página se inician las instancias de productManager y 
        /// imageManager, así como la captura con queryString del parámetro pasado
        /// por GET.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
            {
            ApplicationDbContext context = new ApplicationDbContext();
            productManager = new ProductManager(context);
            imageManager = new ImageManager(context);

            int id = 0;
            if (Request.QueryString["id"] != null)
                {
                if (int.TryParse(Request.QueryString["id"], out id))
                    {
                    var product = productManager.GetById(id);
                    if (product != null)
                        {
                        if (!Page.IsPostBack)
                            LoadProduct(product);
                        }
                    }
                }
            }


        /// <summary>
        /// Obtenemos la id del producto y lo pinta oculto en el aspx
        /// </summary>
        /// <param name="product"></param>
        private void LoadProduct(Product product)
            {
            txtId.Value = product.Id.ToString();



            } 
        #endregion


        #region BtnSubmit_Click
        /// <summary>
        /// Este método atiende al evento clic que va a guardar la imagen en una carpeta del servidor
        /// y registrar su nombre, que contiene un nombre único con su ubicación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSubmit_Click(object sender, EventArgs e)
            {
            try
                {
                Label1.Text = "";

                // Si hay archivo lo carga
                if (FileUpload1.HasFile)
                    {
                    string extension = System.IO.Path.GetExtension(FileUpload1.FileName);

                    //Comprueba que tenga la extensión aceptada
                    if (extension == ".jpg" || extension == ".png" || extension == ".gif")
                        {
                        //Guarda la ubicación del archivo
                        string path = Server.MapPath("~\\Content\\Images\\");

                        //Le da un nombre unívoco gracias a guid
                        string imageName = guid + FileUpload1.FileName;

                        //Salva el nombre con la ubicación
                        FileUpload1.SaveAs(path + imageName);

                        //Crea el objeto con su nombre y le asigna la id de producto al que se vincula
                        Image image = new Image

                            {
                            ImageName = imageName,
                            Product_Id = int.Parse(txtId.Value)
                            };

                        //Persiste el objeto
                        imageManager.Add(image);
                        imageManager.Context.SaveChanges();

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
                string errorHandler = "Error en try/catch de CreateFormImages";

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