using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using Unity;

namespace SportsPromo.App.WebSite
{
    public class GeneralConfig
    {

        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            SportsPromo.App.Dependencias.ConfigureTodos.Configure(container);

            config.DependencyResolver = new DependencyResolver(container);

        }

    }
}
