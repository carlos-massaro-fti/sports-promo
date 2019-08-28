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
    public class MarcoMapeamento
    {
        public static void Configure(IMapperConfigurationExpression configurador)
        {
            configurador.CreateMap<MarcoApp, Marco>()
                .ForMember(src => src.MarcoId, dest => dest.MapFrom(e => e.Id))
                .ForMember(src => src.MarcoLat, dest => dest.MapFrom(e => e.Lat))
                .ForMember(src => src.MarcoLon, dest => dest.MapFrom(e => e.Lon))
                .ForMember(src => src.MarcoProvaId, dest => dest.MapFrom(e => e.ProvaId))
                .ForMember(src => src.MarcoReceptorId, dest => dest.MapFrom(e => e.ReceptorId));




            configurador.CreateMap<Marco, MarcoApp>()
                .ForMember(src => src.Id, dest => dest.MapFrom(e => e.MarcoId))
                .ForMember(src => src.Lat, dest => dest.MapFrom(e => e.MarcoLat))
                .ForMember(src => src.Lat, dest => dest.MapFrom(e => e.MarcoLon))
                .ForMember(src => src.ProvaId, dest => dest.MapFrom(e => e.MarcoProvaId))
                .ForMember(src => src.ReceptorId, dest => dest.MapFrom(e => e.MarcoReceptorId));
        }

       
    }
}
