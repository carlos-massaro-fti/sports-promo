using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsPromo.Comum.Dados;
using SportsPromo.Dominio.Modelos;
using SportsPromo.Interfaces.Dados.Contextos;
using SportsPromo.Interfaces.Dados.Repositorios;

namespace SportsPromo.Dados.Repositorios
{
    public class EsporteRepositorio : BaseRepositorio<Esporte>, IEsporteRepositorio
    {
        public EsporteRepositorio(ISportsPromoContexto contexto) : base(contexto)
        {
        }

        public override long Adicionar(Esporte instancia)
        {
            Contexto.Esportes.Add(instancia);

            Contexto.SaveChanges();

            return instancia.EsporteId;
        }

        public PaginadoOrdenado<Esporte> Listar(PaginadoOrdenado<Esporte> consulta)
        {

            var resultado = new PaginadoOrdenado<Esporte>()
            {
                ItensPorPagina = consulta.ItensPorPagina,
                PaginaAtual = consulta.PaginaAtual,
                OrdemDirecao = consulta.OrdemDirecao,
                OrdemNome = consulta.OrdemNome,
            };

            /*var query = from item in Contexto.Esportes
                        select item;*/

            var query = Contexto.Esportes.AsQueryable();


            resultado.SetTotalDeLinhas(query.Count());

            if (consulta.OrdemDirecao == 0)
            {
                switch (consulta.OrdemNome)
                {
                    case "EsporteNome":
                        query = query.OrderBy(e => e.EsporteNome);
                        break;
                    case "EsporteId":
                    default:
                        query = query.OrderBy(e => e.EsporteId);
                        break;
                }
            }
            else
            {
                switch (consulta.OrdemNome)
                {
                    case "EsporteNome":
                        query = query.OrderByDescending(e => e.EsporteNome);
                        break;
                    case "EsporteId":
                    default:
                        query = query.OrderByDescending(e => e.EsporteId);
                        break;
                }
            }
            if (!(query is IOrderedQueryable))
            {
                query = query.OrderBy(e => e.EsporteId);
            }

            query = query
                .Skip(resultado.ItensPorPagina * (resultado.PaginaAtual - 1))
                .Take(resultado.ItensPorPagina);

            resultado.Itens = query;

            return resultado;
        }
    }
}
