using EShop.APPLICATION;
using EShop.CORE;
using EShop.DAL;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EShop.Admin
    {
    public partial class CreateFormProduct : System.Web.UI.Page
        {
        #region Page_Load
        ProductManager productManager = null;
        ImageManager imageManager = null;
        CategoryManager categoryManager = null;

        //Crea un identificador único
        string guid = Guid.NewGuid().ToString();


        /// <summary>
        /// Al cargar crea los objetos image,product y category
        /// para poder trabajar con el contexto (la bdd)
        /// y carga una sola vez (postBack) el desplegable con las posibles categorías.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
            {
            ApplicationDbContext context = new ApplicationDbContext();
            productManager = new ProductManager(context);
            imageManager = new ImageManager(context);
            categoryManager = new CategoryManager(context);

            if (!Page.IsPostBack)
                {
                var categoryForDropdown = categoryManager.GetAll(); //probar

                DropDownList1.DataSource = categoryForDropdown.ToList();

                //Definimos el campo que contendrá los valores para el control
                //DataTextField="CategoryName" DataValueField="Id"

                DropDownList1.DataValueField = "Id";

                //Definimos el campo que contendrá los textos que se verán en el control

                DropDownList1.DataTextField = "CategoryName";

                //Enlazamos los valores de los datos con el contenido del Control

                DropDownList1.DataBind();

                }
            }

        #endregion


        #region BtnSubmitImagen_Click guarda imagen
        
        
        /// <summary>
        /// Carga la imagen seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSubmitImagen_Click(object sender, EventArgs e)
            {
            try
                {
                Label1.Text = "";

                //Si no hay archivo lo carga
                if (FileUpload1.HasFile)
                    {
                    string extension = System.IO.Path.GetExtension(FileUpload1.FileName);


                    //Comprueba que tenga la extensión aceptada
                    if (extension == ".jpg" || extension == ".png" || extension == ".gif")
                        {

                        //Guarda la ubicación del archivo
                        string path = Server.MapPath("~\\Content\\Images\\");

                        //Le da un nombre unívoco gracias al guid
                        string imageName = guid + FileUpload1.FileName;

                        //Salva el nombre con la ubicación
                        FileUpload1.SaveAs(path + imageName);

                        //Pinta el nombre en la página para poder recuperarla
                        //posteriormente al persistir el objeto
                        txtLabelImageName.Text = imageName;

                        //Mensaje si todo ha ido bien
                        txtLabel.Text = "Imagen guardada";
                        }
                    else
                        {
                        //Mensaje si se ha escogido un archivo que no es una imagen válida
                        txtLabel.Text = "La imagen ha de tener extensión jpg, png o gif";
                        }

                    }
                else
                    {
                    //mensaje si se pulsa guardar sin haber escogido ningún archivo de imagen
                    txtLabel.Text = "Por favor selecciona una imagen";
                    }

                }

            catch (Exception ex)
                {
                //Identifico la página
                string errorHandler = "Error en try/catch de CreateFormProduct";

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



        #region Guarda producto
        /// <summary>
        /// Este método va a colectar de los diferentes textbox las propiedades del nuevo
        /// objeto product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSubmit_Click(object sender, EventArgs e)
            {
            try
                {
                Product product = new Product
                    {

                    ProductName = txtProductName.Text,
                    ProductDescription = txtProductDescription.Text,
                    ProductPrice = float.Parse(textProductPrice.Text),
                    Category_Id = int.Parse(DropDownList1.Text),
                    Stock = int.Parse(textStock.Text),
                    ImagePath = txtLabelImageName.Text,


                    };


                productManager.Add(product);
                productManager.Context.SaveChanges();

                txtProductDescription.Text = string.Empty;
                txtProductName.Text = string.Empty;
                textStock.Text = string.Empty;
                textProductPrice.Text = string.Empty;

                Response.Redirect("ProductListAdmin");
                }
            catch (Exception ex)
                {
                //Identifico la página
                string errorHandler = "Error en try/catch de CreateFormProduct";

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