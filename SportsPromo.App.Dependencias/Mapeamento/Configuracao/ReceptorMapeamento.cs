using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SportsPromo.App.Core.Modelos;
using SportsPromo.App.Modelos;
using SportsPromo.Dominio.Modelos;

namespace SportsPromo.App.Dependencias.Mapeamento.Configuracao
{
    class ReceptorMapeamento
    {
        public static void Configure(IMapperConfigurationExpression configurador)
        {
            configurador.CreateMap<ReceptorApp, Receptor>()
                .ForMember(src => src.ReceptorId, dest => dest.MapFrom(e => e.Id))
                .ForMember(src => src.ReceptorCodigo, dest => dest.MapFrom(e => e.Codigo));

            configurador.CreateMap<Receptor, ReceptorApp>()
                .ForMember(src => src.Id, dest => dest.MapFrom(e => e.ReceptorId))
                .ForMember(src => src.Codigo, dest => dest.MapFrom(e => e.ReceptorCodigo));
        }
    }
}
