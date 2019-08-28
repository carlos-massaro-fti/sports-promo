using SportsPromo.App.Core.Manipuladores;
using SportsPromo.App.Interfaces.Manipuladores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;


namespace SportsPromo.App.Dependencias.Manipuladores
{
    public class ConfigureManipulador
    {
        public static void Configure(IUnityContainer container)
        {
            container.RegisterType<IGeneroManipulador, GeneroManipulador>(new HierarchicalLifetimeManager());
            container.RegisterType<IEsporteManipulador, EsporteManipulador>(new HierarchicalLifetimeManager());
            container.RegisterType<IChecagemManipulador, ChecagemManipulador>(new HierarchicalLifetimeManager());
        }
    }
}
