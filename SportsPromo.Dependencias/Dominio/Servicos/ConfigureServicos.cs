using SportsPromo.Dominio.Servicos;
using SportsPromo.Interfaces.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace SportsPromo.Dependencias.Dominio.Servicos
{
    public class ConfigureServicos
    {
        public static void Configure(IUnityContainer container)
        {
            container.RegisterType<IGeneroServico, GeneroServico>(new HierarchicalLifetimeManager());
            container.RegisterType<IReceptorServico, ReceptorServico>(new HierarchicalLifetimeManager());
            container.RegisterType<IEsporteServico, EsporteServico>(new HierarchicalLifetimeManager());
            container.RegisterType<IChecagemServico, ChecagemServico>(new HierarchicalLifetimeManager());
        }
    }
}
