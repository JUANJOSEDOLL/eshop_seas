using EShop.APPLICATION;
using EShop.CORE;
using EShop.DAL;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EShop.Admin
    {
    public partial class EditFormProduct : System.Web.UI.Page
        {

        #region Page_Load
        ProductManager productManager = null;
        /// <summary>
        /// En el momento de cargar la página recogemos la id que manda el list de productos
        /// Con la id cargamos el objeto producto que nos ocupa para su posterior edición de 
        /// sus propiedades
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
                            LoadProduct(product);
                        }
                    }
                }
            } 
        #endregion


        #region LoadProduct
        /// <summary>
        /// Este método nos permitellenar los textBox del aspx con los atributos del
        /// objeto producto seleccionado
        /// </summary>
        /// <param name="product"></param>
        private void LoadProduct(Product product)
            {
            ApplicationDbContext context = new ApplicationDbContext();

            //Obtenemos del imageManager la colección de imágenes de la BDD

            ImageManager imageManager = new ImageManager(context);

            //Esta variable cargará las imágenes del producto que nos ocupa

            var imagesOfProduct = imageManager.GetByProductId(product.Id);

            //Indicamos cúales van a ser los datos a asociar

            DropDownList2.DataSource = imagesOfProduct.ToList(); ;

            ////Definimos el campo que contendrá los valores para el control

            DropDownList2.DataValueField = "ImageName";

            ////Definimos el campo que contendrá los textos que se verán en el control

            DropDownList2.DataTextField = "Id";

            ////Enlazamos los valores de los datos con el contenido del Control

            DropDownList2.DataBind();


            CategoryManager categoryManager = new CategoryManager(context);

            var categoryForDropdown = categoryManager.GetAll(); //probar

            dropDownListCategory.DataSource = categoryForDropdown.ToList();

            //Definimos el campo que contendrá los valores para el control
            //DataTextField="CategoryName" DataValueField="Id"

            dropDownListCategory.DataValueField = "Id";

            //Definimos el campo que contendrá los textos que se verán en el control

            dropDownListCategory.DataTextField = "CategoryName";

            //Enlazamos los valores de los datos con el contenido del Control

            dropDownListCategory.DataBind();

            //Cargamos los cuadros de texto del formulario

            txtId.Value = product.Id.ToString();
            txtProductName.Text = product.ProductName;
            txtProductDescription.Text = product.ProductDescription;
            textProductPrice.Text = product.ProductPrice.ToString();
            dropDownListCategory.Text = product.Category_Id.ToString();
            textStock.Text = product.Stock.ToString();
            image1.ImageUrl = "/Content/Images/" + product.ImagePath;

            }
        #endregion


        #region BtnSubmit_Click
        /// <summary>
        /// Este método actualiza el registro de producto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSubmit_Click(object sender, EventArgs e)
            {
            try
                {

                var product = productManager.GetById(int.Parse(txtId.Value));

                product.ProductName = txtProductName.Text;
                product.ProductDescription = txtProductDescription.Text;
                product.ProductPrice = float.Parse(textProductPrice.Text);
                product.Category_Id = int.Parse(dropDownListCategory.Text);
                product.Stock = int.Parse(textStock.Text);
                product.ImagePath = DropDownList2.Text;

                productManager.Context.SaveChanges();

                Response.Redirect("/Admin/EditFormProduct?id=" + txtId.Value);

                }
            catch (Exception ex)
                {
                //Identifico la página
                string errorHandler = "Error en try/catch de EditFormProduct";

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