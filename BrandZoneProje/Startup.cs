using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BrandZoneProje.Startup))]
namespace BrandZoneProje
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
