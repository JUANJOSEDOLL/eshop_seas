using EShop.APPLICATION;
using EShop.CORE;
using EShop.DAL;
using System;
using System.Web.UI;

namespace EShop.User
    {
    public partial class ProductDetails : System.Web.UI.Page
        {
        #region Page_Load carga de producto
        ProductManager productManager = null;
        ImageManager imageManager = null;
        CategoryManager categoryManager = null;


        /// <summary>
        /// Al cargarse la página se va a recoger por queryString (GET)
        /// la id pasada por parámetro desde el productList al ser seleccionado el producto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void Page_Load(object sender, EventArgs e)
            {
            ApplicationDbContext context = new ApplicationDbContext();
            productManager = new ProductManager(context);
            imageManager = new ImageManager(context);
            categoryManager = new CategoryManager(context);

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
        /// Este método carga como parámetro el producto escogido como objeto
        /// En el objeto product se encuentra encapsuladas todas la propiedades
        /// Por lo que vamos a poder obtener todas sus propiedades, incluso la 
        /// colección de imágenes que contiene.
        /// </summary>
        /// <param name="product"></param>
        private void LoadProduct(Product product)
            {


            //Obtenemos su categoría
            string txtCategoryName = categoryManager.GetById(product.Category_Id).CategoryName;

            //Obtenemos la colección de imágenes
            var imagesOfThisProduct = product.Images;

            //La colección de imágenes la usamos para llenar un repeater
            Repeater1.DataSource = imagesOfThisProduct;
            Repeater1.DataBind();

            //Bajo el repeater, que va a ser un slider, pásaremos el resto de 
            //propiedades del producto
            txtProductName.Text = product.ProductName;
            txtProductDescription.Text = product.ProductDescription;
            txtProductPrice.Text = product.ProductPrice.ToString() + " €";
            txtCategory.Text = txtCategoryName;
            txtStock.Text = product.Stock.ToString() + " Unidades";

            //Esta ruta de imagen corresponde a la imagen principal
            txtImagePath.ImageUrl = "/Content/Images/" + product.ImagePath;



            } 
        #endregion

        }
    }