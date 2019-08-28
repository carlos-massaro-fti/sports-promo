using AutoMapper;
using SportsPromo.App.Core.Modelos;
using SportsPromo.App.Modelos;
using SportsPromo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.App.Dependencias.Mapeamento.Configuracao
{
    public class ChecagemMapeamento
    {
        public static void Configure(IMapperConfigurationExpression configurador)
        {
            configurador.CreateMap<ChecagemApp, Checagem>()
                .ForMember(src => src.ChecagemId, dest => dest.MapFrom(e => e.Id))
                .ForMember(src => src.ChecagemRfid, dest => dest.MapFrom(e => e.Rfid));

            configurador.CreateMap<Checagem, ChecagemApp>()
                .ForMember(src => src.Id, dest => dest.MapFrom(e => e.ChecagemId))
                .ForMember(src => src.Rfid, dest => dest.MapFrom(e => e.ChecagemRfid));
        }
    }
}
