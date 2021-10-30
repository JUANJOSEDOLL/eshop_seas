using EShop.CORE;
using EShop.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace EShop
    {
    public class Global : HttpApplication

        {
        //Con este método interceptaremos los errores que se produzcan en cualquier parte de la aplicación
        //agregando código al controlador de Application_Error

        void Application_Error(object sender, EventArgs e)
            {
            Exception exc = Server.GetLastError();

            if (exc is HttpUnhandledException)
                {
                // Pass the error on to the error page.
                Server.Transfer("Oops.aspx?handler=Application_Error%20-%20Global.asax", true);
                }
            }

        //Iniciamos una sesion y no se genera un nuevo id hasta que no se cierra 
        //el navegador

        protected void Session_Start(Object sender, EventArgs e)
            {
            Session["init"] = 0;
            }




        void Application_Start(object sender, EventArgs e)
            {



            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Configuramos seguridad
            ApplicationDbContext context = new ApplicationDbContext();
            RoleManager<IdentityRole> roleManager =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));
            UserManager<ApplicationUser> userManager =
                new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new IdentityRole("Admin"));

            if (!roleManager.RoleExists("Client"))
                roleManager.Create(new IdentityRole("Client"));

            ApplicationUser user = userManager.FindByName("admin@admin.com");
            if (user == null)
                {
                user = new ApplicationUser();
                user.UserName = "admin@admin.com";
                user.Email = "admin@admin.com";
                IdentityResult result = userManager.Create(user, "123Asd<");
                if (result.Succeeded)
                    {
                    userManager.AddToRole(user.Id, "Admin");
                    }
                else
                    {
                    throw new Exception("Usuario no creado");
                    }
                }
            else
                {
                //El usuario está creado, ¿Pero ya esta en el rol admin?
                if (!userManager.IsInRole(user.Id, "Admin"))
                    {
                    userManager.AddToRole(user.Id, "Admin");
                    }
                }
            }
        }
    }