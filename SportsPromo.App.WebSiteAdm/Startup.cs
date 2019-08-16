using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SportsPromo.App.WebSiteAdm.Startup))]
namespace SportsPromo.App.WebSiteAdm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
