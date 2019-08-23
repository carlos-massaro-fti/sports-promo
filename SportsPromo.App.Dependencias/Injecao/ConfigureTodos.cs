using SportsPromo.App.Dependencias.Manipuladores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace SportsPromo.App.Dependencias
{
    public class ConfigureTodos
    {
        public static void Configure(IUnityContainer container)
        {
            SportsPromo.Dependencias.ConfigureTodos.Configure(container);
            Mapeamento.Mapeamento.Inicializar(container);
            ConfigureManipulador.Configure(container);
        }
    }
}
