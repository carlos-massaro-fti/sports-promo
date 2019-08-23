using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using SportsPromo.App.Core.Modelos;
using SportsPromo.Dominio.Modelos;

namespace SportsPromo.App.Dependencias.Mapeamento.Configuracao
{
    public class EsporteMapeamento
    {
        public static void Configure(IMapperConfigurationExpression configurador)
        {
            configurador.CreateMap<EsporteApp, Esporte>()
                .ForMember(src => src.EsporteId, dest => dest.MapFrom(e => e.Id))
                .ForMember(src => src.EsporteNome, dest => dest.MapFrom(e => e.Nome));

            configurador.CreateMap<Esporte, EsporteApp>()
                .ForMember(src => src.Id, dest => dest.MapFrom(e => e.EsporteId))
                .ForMember(src => src.Nome, dest => dest.MapFrom(e => e.EsporteNome));
        }
    }
}
