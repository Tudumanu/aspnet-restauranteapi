using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace WebAPIServices.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class WebAPIServicesContext : IdentityDbContext<ApplicationUser>
    {
        public WebAPIServicesContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static WebAPIServicesContext Create()
        {
            return new WebAPIServicesContext();
        }

        public System.Data.Entity.DbSet<WebAPIServices.Models.Restaurante> Restaurantes { get; set; }

        public System.Data.Entity.DbSet<WebAPIServices.Models.Garcom> Garcoms { get; set; }

        public System.Data.Entity.DbSet<WebAPIServices.Models.Pedido> Pedidoes { get; set; }
    }
}