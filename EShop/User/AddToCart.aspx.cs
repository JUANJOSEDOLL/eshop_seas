using EShop.APPLICATION;
using EShop.CORE;
using EShop.DAL;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using Product = EShop.CORE.Product;

namespace EShop.User
    {
    public partial class AddToCart : System.Web.UI.Page
        {

        ProductManager productManager = null;
        CartItemManager cartItemManager = null;

        public string ShoppingCartId { get; set; }
        public const string CartSessionKey = "MiSesion";

        /// <summary>
        /// Al cargar la página el sistema recoge el parámetro id, lanzado por http GET 
        /// desde la página aspx ProductList. El ID servirá para identificar el producto
        /// escogido, que se pasará por parámetro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
            {
            ApplicationDbContext context = new ApplicationDbContext();
            productManager = new ProductManager(context);
            cartItemManager = new CartItemManager(context);


            int id = 0;
            if (Request.QueryString["Id"] != null)
                {
                if (int.TryParse(Request.QueryString["Id"], out id))
                    {
                    var product = productManager.GetById(id);
                    if (product != null)
                        {

                        LoadCartItem(product);

                        }
                    }
                }
            }

        /// <summary>
        /// Este método obtiene número de unidades del producto escogido para el id de carrito
        /// </summary>
        /// <param name="cId">Id del carrito</param>
        /// <param name="pId">Id del producto</param>
        /// <returns></returns>
        public int GetQuantity(string cId, int pId)
            {
            var productInCart = cartItemManager.GetByCartId(cId);

            var productById = productInCart.FirstOrDefault(p => p.Product_Id == pId);


            if (productById != null)
                {
                int quantityInItem = 0;
                quantityInItem = productById.Quantity + 1;



                return quantityInItem;
                }
            else
                {
                return 1;
                }

            }





        /// <summary>
        /// Este método va a añadir al carrito una unidad del producto seleccionado
        /// </summary>
        /// <param name="product"></param>
        public void LoadCartItem(Product product)
            {
            //TODO try-catch

            //Se recoge en esta variable el número de unidades del producto escogido para el id de carrito
            int ItemQuantity = GetQuantity(GetCartId(), product.Id);


            //Comprueba si hay previamente el producto cargado en el carrito
            //Si ya hay uno lo añade
            //Si no hay ninguno lo añade como objeto con todos los atributos
            if (ItemQuantity != 1)
                {
                var cartItemExist = cartItemManager.GetByCartId(GetCartId());

                var productById = cartItemExist.FirstOrDefault(p => p.Product_Id == product.Id);

                productById.Quantity = ItemQuantity;




                cartItemManager.Context.SaveChanges();

                Response.Redirect("ProductList");



                }
            else
                {



                CartItem cartItem = new CartItem
                    {
                    Product_Id = product.Id,
                    CartId = GetCartId(),
                    Quantity = ItemQuantity,
                    ProductName = product.ProductName,
                    ProductPrice = product.ProductPrice,
                    DateCreated = DateTime.Now

                    };

                try
                    {
                    cartItemManager.Add(cartItem);

                    cartItemManager.Context.SaveChanges();

                    Response.Redirect("ProductList");


                    }
                catch (DbEntityValidationException ex)
                    {
                    //Identifico la página
                    string errorHandler = "Error en try/catch de AddToCart";

                    //Creo un log a través de un método creado para ello
                    //Este metodo creará un archivo de texto en la carpeta App_data
                    //que genera información sobre el error y lo localiza
                    ExceptionUtility.LogException(ex, errorHandler);

                    //Una vez generado registro redirige al usuario hacia una página de error
                    //pero en ningún caso da mensajes por pantalla que puedan afectar a la seguridad del sitio
                    Server.Transfer("/ErrorPages/Oops.aspx?handler=Application_Error%20-%20Global.asax", true);
                    }

                }

            }

        /// <summary>
        /// Este método obtiene la id del carrito vigente
        /// </summary>
        /// <returns></returns>
        public string GetCartId()
            {

            return HttpContext.Current.Session.SessionID;
            }



        }
    }