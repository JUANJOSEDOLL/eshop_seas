using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EShop.CORE
    {

    #region Genera user identity
    // Para agregar datos del usuario, agregue más propiedades a su clase de usuario. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
        {
        public ClaimsIdentity GenerateUserIdentity(UserManager<ApplicationUser> manager)
            {
            // Tenga en cuenta que authenticationType debe coincidir con el valor definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar reclamaciones de usuario personalizadas aquí
            return userIdentity;
            }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
            {
            return Task.FromResult(GenerateUserIdentity(manager));
            }
        #endregion
        #region Propiedades user
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Apellido de usuario
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Dirección del usuario
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Código postal
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Ciudad de la dirección del usuario
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Provincia de la dirección del usuario
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// País de la dirección del usuario
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Telefono del usuario
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Identificador fiscal usuario
        /// </summary>
        public string Cif_Nif { get; set; }

        //NO de usa por ser por pasarela, no se graban datos pago cliente
        ///// <summary>
        ///// Número de tarjeta credito
        ///// </summary>
        [CreditCard(ErrorMessage = "Tarjeta inválida")]
        public string CreditCardNumber { get; set; }


        #endregion





        }

    }
