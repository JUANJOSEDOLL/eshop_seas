using EShop.APPLICATION;
using EShop.CORE;
using EShop.DAL;
using System;
using System.Web.UI;


namespace EShop.User
    {
    public partial class DeleteRowCartItemList : System.Web.UI.Page
        {
        CartItemManager cartItemManager = null;




        /// <summary>
        /// En la carga de la página se obtiene por http GET la id que lanza el método delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
            {
            ApplicationDbContext context = new ApplicationDbContext();
            cartItemManager = new CartItemManager(context);


            int id = 0;
            if (Request.QueryString["id"] != null)
                {
                if (int.TryParse(Request.QueryString["id"], out id))
                    {
                    var cartItem = cartItemManager.GetById(id);
                    if (cartItem != null)
                        {
                        if (!Page.IsPostBack)
                            DeleteCartItem(cartItem);
                        }
                    }
                }
            }
        /// <summary>
        /// Este método elimina del carrito el elemento seleccionado
        /// </summary>
        /// <param name="cartItem"></param>
        private void DeleteCartItem(CartItem cartItem)
            {
            cartItemManager.Remove(cartItem);
            cartItemManager.Context.SaveChanges();
            Response.Redirect("CartItemList");



            }


        }
    }