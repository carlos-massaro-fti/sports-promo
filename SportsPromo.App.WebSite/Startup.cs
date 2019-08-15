using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SportsPromo.App.WebSite.Startup))]
namespace SportsPromo.App.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
