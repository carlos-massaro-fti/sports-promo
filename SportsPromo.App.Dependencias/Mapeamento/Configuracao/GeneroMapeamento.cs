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
    public class GeneroMapeamento
    {
        public static void Configure(IMapperConfigurationExpression configurador)
        {
            configurador.CreateMap<GeneroApp, Genero>()
                .ForMember(src => src.GeneroId, dest => dest.MapFrom(e => e.Id))
                .ForMember(src => src.GeneroNome, dest => dest.MapFrom(e => e.Nome));

            configurador.CreateMap<Genero, GeneroApp>()
                .ForMember(src => src.Id, dest => dest.MapFrom(e => e.GeneroId))
                .ForMember(src => src.Nome, dest => dest.MapFrom(e => e.GeneroNome));
        }
    }
}
