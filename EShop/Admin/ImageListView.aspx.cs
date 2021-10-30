using EShop.APPLICATION;
using EShop.DAL;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using Image = EShop.CORE.Image;

namespace EShop.Admin
    {
    public partial class ImageListView : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {


            }


        /// <summary>
        /// Método que retorna todas los Imagenes
        /// </summary>

        public IQueryable<Image> lvImages_GetData()
            {
            ApplicationDbContext context = new ApplicationDbContext();
            ImageManager imageManager = new ImageManager(context);

            var images = imageManager.GetAll();

            return images;
            }




        protected void lvImages_ItemCommand(object sender, ListViewCommandEventArgs e)
            {
            ApplicationDbContext context = new ApplicationDbContext();
            ImageManager imageManager = new ImageManager(context);

            if (e.CommandName == "Eliminar")
                {
                var id = Convert.ToInt32(e.CommandArgument);

                var image = imageManager.GetById(id);
                if (image != null)
                    {

                    imageManager.Remove(image);
                    lvImages.DataBind();

                    }

                }

            }


        }
    }