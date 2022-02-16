using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdoptToShop.Startup))]
namespace AdoptToShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
