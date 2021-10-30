
using EShop.APPLICATION;
using EShop.DAL;
using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace EShop.User
    {
    public partial class ProductList : System.Web.UI.Page
        {
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
            {
            ApplicationDbContext context = new ApplicationDbContext();
            ProductManager productManager = new ProductManager(context);
            ImageManager imageManager = new ImageManager(context);
            CategoryManager categoryManager = new CategoryManager(context);


            ///En una primera carga de la página
            ///se llenan todos los items tanto de la lista de productos
            ///como la lista de categorias


            if (!IsPostBack)
                {
                var categories = categoryManager.GetAll().ToList();

                Repeater2.DataSource = categories;
                Repeater2.DataBind();

                var allProducts = productManager.GetAll().ToList();

                Repeater1.DataSource = allProducts;
                Repeater1.DataBind();

                }


            //Obtenemos el acceso a la base de datos del carrito

            CartItemManager cartItemManager = new CartItemManager(context);

            //Obtenemos la sesión actual

            string sessionId = HttpContext.Current.Session.SessionID;

            //Con el objeto carrito y el parámetro de la sesion filtramos los items del carrito actual

            var countItems = cartItemManager.GetByCartId(sessionId).Count();

            //Lo pintamos oculto en el front-end, así lo tenemos disponible

            txtLabel.Text = countItems.ToString();

            //Por otro lado montamos un método que nos devuelva  las unidades totales
            //del id de producto que les pasemos por parámetro.






            int id = 0;
            if (Request.QueryString["Id"] != null)
                {
                if (int.TryParse(Request.QueryString["Id"], out id))
                    {

                    var filteredProducts = productManager.GetByCategoryId(id).ToList();

                    if (filteredProducts != null)
                        {
                        Repeater1.DataSource = filteredProducts;
                        Repeater1.DataBind();
                        }
                    }
                }


            }
        #endregion

        #region R1_ItemDataBound
        /// <summary>
        /// Este método permite identificar los valores que contiene cada item del repeater
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        protected void R1_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
            {


            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                //creamos el objeto item del repeater
                RepeaterItem item = e.Item;



                //Identificamos el stock de cada uno de los items una vez cargado, pero antes de renderizar

                int stock = int.Parse((item.FindControl("Label1") as Label).Text);


                //Identificamos el elemento linkbutton de cada item

                LinkButton linkButton = (LinkButton)item.FindControl("LinkButton1");


                //Vamos a preguntar a cada item su stock, si es mayor que 0
                //le diremos que renderice un boton activo de bootstrap,si es 0,
                //le diremos que lo renderice como inactivo

                if (stock > 0)
                    {
                    linkButton.CssClass = "btn btn-primary";
                    }
                else
                    {
                    linkButton.CssClass = "btn btn-primary disabled";
                    }

                }


            }
        #endregion

        #region Lbt_Click
        /// <summary>
        /// Este método recoge desde aspx la id de producto seleccionado en el repeater 
        /// para añadirlo a la cesta.
        /// Previamente ha de comprobar que el stock del id pasado es igual o superior
        /// a la cantidad de ese id de producto acumulada en el carrito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Lbt_Click(object sender, EventArgs e)
            {
            string idParameter = ((LinkButton)sender).CommandArgument;

            //Obtenemos el stock del carrito para esta sesion y el id de producto

            ApplicationDbContext context = new ApplicationDbContext();
            CartItemManager cartItemManager = new CartItemManager(context);

            //Obtenemos la sesión actual

            string sessionId = HttpContext.Current.Session.SessionID;

            //casteamos el IdParameter para poder filtrar como id de producto en el carrito

            int idParameterInt = int.Parse(idParameter);

            var countItemsfiltered = cartItemManager.GetByCartId(sessionId).Where(x => x.Product_Id == idParameterInt).Count();

            //Y ahora obtenemos el stock del producto según la base de datos de producto

            ProductManager productManager = new ProductManager(context);

            var stock = productManager.GetById(idParameterInt).Stock;

            if (stock > countItemsfiltered)
                {

                Response.Redirect("AddToCart.aspx?Id=" + idParameter);

                }
            else
                {

                Response.Redirect("ProductList.aspx");

                }




            }




        #endregion

        }
    }