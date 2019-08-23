using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using SportsPromo.App.Dependencias.Mapeamento.Configuracao;
using Unity;

namespace SportsPromo.App.Dependencias.Mapeamento
{
    public class Mapeamento
    {
        public static void Inicializar(IUnityContainer container)
        {
            var configuracao = new MapperConfiguration(cfg =>
            {
                EsporteMapeamento.Configure(cfg);
                GeneroMapeamento.Configure(cfg);
            });
            container.RegisterInstance<IMapper>(new Mapper(configuracao));
        }
    }
}
