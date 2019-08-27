using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SportsPromo.App.Core.Modelos;
using SportsPromo.Dominio.Modelos;

namespace SportsPromo.App.Dependencias.Mapeamento.Configuracao
{
    public class CategoriaMapeamento
    {
        public static void Configure(IMapperConfigurationExpression configurador)
        {
            configurador.CreateMap<CategoriaApp, Categoria>()
                .ForMember(src => src.CategoriaId, dest => dest.MapFrom(e => e.Id))
                .ForMember(src => src.CategoriaNome, dest => dest.MapFrom(e => e.Nome))
                .ForMember(src => src.CategoriaIdadeMin, dest => dest.MapFrom(e => e.IdadeMin))
                .ForMember(src => src.CategoriaIdadeMax, dest => dest.MapFrom(e => e.IdadeMax));

            configurador.CreateMap<Categoria, CategoriaApp>()
                .ForMember(src => src.Id, dest => dest.MapFrom(e => e.CategoriaId))
                .ForMember(src => src.Nome, dest => dest.MapFrom(e => e.CategoriaNome))
                .ForMember(src => src.IdadeMin, dest => dest.MapFrom(e => e.CategoriaIdadeMin))
                .ForMember(src => src.IdadeMax, dest => dest.MapFrom(e => e.CategoriaIdadeMax));
        }

    }
}
