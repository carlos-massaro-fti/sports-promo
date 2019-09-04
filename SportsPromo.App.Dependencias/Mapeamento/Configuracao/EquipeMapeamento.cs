using AutoMapper;
using SportsPromo.App.Modelos;
using SportsPromo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.App.Dependencias.Mapeamento.Configuracao
{
    public class EquipeMapeamento
    {
        public static void Configure(IMapperConfigurationExpression configurador)
        {
            configurador.CreateMap<EquipeApp, Equipe>()
                .ForMember(src => src.EquipeId, dest => dest.MapFrom(e => e.Id))
                .ForMember(src => src.EquipeNome, dest => dest.MapFrom(e => e.Nome))
                .ForMember(src => src.EquipeProvaId, dest => dest.MapFrom(e => e.EquipeProvaId))
                ;

            configurador.CreateMap<Equipe, EquipeApp>()
                .ForMember(src => src.Id, dest => dest.MapFrom(e => e.EquipeId))
                .ForMember(src => src.Nome, dest => dest.MapFrom(e => e.EquipeNome))
                .ForMember(src => src.EquipeProvaId, dest => dest.MapFrom(e => e.EquipeProvaId))
                ;
        }
    }
}
