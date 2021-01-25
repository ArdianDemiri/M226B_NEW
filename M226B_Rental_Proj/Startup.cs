using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(M226B_Rental_Proj.Startup))]
namespace M226B_Rental_Proj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
