using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace SportsPromo.Dependencias
{
    public class ConfigureTodos
    {
        public static void Configure(IUnityContainer container)
        {
            Dados.Contextos.ConfigureContextos.Configure(container);
            Dados.Repositorios.ConfigureRepositorios.Configure(container);
            Dominio.Servicos.ConfigureServicos.Configure(container);
        }
    }
}
