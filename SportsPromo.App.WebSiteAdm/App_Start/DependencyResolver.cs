using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;

namespace SportsPromo.App.WebSiteAdm.App_Start
{
    public class DependencyResolver: System.Web.Http.Dependencies.IDependencyResolver
    {
        static public IUnityContainer Container = new UnityContainer();

        public DependencyResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            Container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return Container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return Container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            var child = Container.CreateChildContainer();
            return new DependencyResolver(child);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            Container.Dispose();
        }

     
    }
}