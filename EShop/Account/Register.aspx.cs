﻿using EShop.CORE;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace EShop.Account
    {
    public partial class Register : Page
        {
        protected void CreateUser_Click(object sender, EventArgs e)
            {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser()
                {
                UserName = Email.Text,
                Email = Email.Text,
                Address = txtAddress.Text,
                City = txtCity.Text,
                Country = txtCountry.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Phone = txtPhone.Text,
                PostalCode = txtPostalCode.Text,
                Province = txtProvince.Text,
                Cif_Nif = txtCif_Nif.Text
                };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
                {
                // Para obtener más información sobre cómo habilitar la confirmación de cuentas y el restablecimiento de contraseña, visite https://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirmar cuenta", "Para confirmar la cuenta, haga clic <a href=\"" + callbackUrl + "\">aquí</a>.");

                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
            else
                {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
                }
            }
        }
    }