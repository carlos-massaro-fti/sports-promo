using SportsPromo.Dados.Contextos;
using SportsPromo.Dominio.Servicos;
using SportsPromo.Interfaces.Dados.Contextos;
using SportsPromo.Interfaces.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;



namespace SportsPromo.Dependencias.Dados.Contextos
{
    public class ConfigureContextos
    {
        public static void Configure(IUnityContainer container)
        {
            container.RegisterType<ISportsPromoContexto, SportsPromoContexto>(new HierarchicalLifetimeManager());
        }
    }
}
