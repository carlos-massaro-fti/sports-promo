using SportsPromo.Dados.Repositorios;
using SportsPromo.Interfaces.Dados.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;


namespace SportsPromo.Dependencias.Dados.Repositorios
{
    public class ConfigureRepositorios
    {
        public static void Configure(IUnityContainer container)
        {
            container.RegisterType<IGeneroRepositorio, GeneroRepositorio>(new HierarchicalLifetimeManager());
            container.RegisterType<IReceptorRepositorio, ReceptorRepositorio>(new HierarchicalLifetimeManager());
            container.RegisterType<IEsporteRepositorio, EsporteRepositorio>(new HierarchicalLifetimeManager());
            container.RegisterType<ICategoriaRepositorio, CategoriaRepositorio>(new HierarchicalLifetimeManager());
        }
    }
}
