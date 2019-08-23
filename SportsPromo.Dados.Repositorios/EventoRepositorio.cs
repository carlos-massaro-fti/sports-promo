using SportsPromo.Comum.Dados;
using SportsPromo.Dominio.Modelos;
using SportsPromo.Interfaces.Dados.Contextos;
using SportsPromo.Interfaces.Dados.Repositorios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Dados.Repositorios
{
    public class EventoRepositorio : BaseRepositorio<Evento>, IEventoRepositorio
    {
        public EventoRepositorio(ISportsPromoContexto contexto) : base(contexto)
        {
        }

        public override long Adicionar(Evento instancia)
        {
            Contexto.Eventos.Add(instancia);

            Contexto.SaveChanges();

            return instancia.EventoId;
        }

        public Task<long> AdicionarAsync(Evento instancia)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AlterarAsync(Evento instancia)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarAsync(long id)
        {
            throw new NotImplementedException();
        }

        public PaginadoOrdenado<Evento> Listar(PaginadoOrdenado<Evento> consulta)
        {

            var resultado = new PaginadoOrdenado<Evento>()
            {
                ItensPorPagina = consulta.ItensPorPagina,
                PaginaAtual = consulta.PaginaAtual,
                OrdemDirecao = consulta.OrdemDirecao,
                OrdemNome = consulta.OrdemNome,
            };

            /*var query = from item in Contexto.Esportes
                        select item;*/

            var query = Contexto.Eventos.AsQueryable();


            resultado.SetTotalDeLinhas(query.Count());

            if (consulta.OrdemDirecao == 0)
            {
                switch (consulta.OrdemNome)
                {
                    case "EventoDataInicio":
                        query = query.OrderBy(e => e.EventoDataInicio);
                        break;
                    case "EventoId":
                    default:
                        query = query.OrderBy(e => e.EventoId);
                        break;
                }
            }
            else
            {
                switch (consulta.OrdemNome)
                {
                    case "EventoDataInicio":
                        query = query.OrderByDescending(e => e.EventoDataInicio);
                        break;
                    case "EventoId":
                    default:
                        query = query.OrderByDescending(e => e.EventoId);
                        break;
                }
            }
            if (!(query is IOrderedQueryable))
            {
                query = query.OrderBy(e => e.EventoId);
            }

            query = query
                .Skip(resultado.ItensPorPagina * (resultado.PaginaAtual - 1))
                .Take(resultado.ItensPorPagina);

            resultado.Itens = query;

            return resultado;
        }

        public async Task<PaginadoOrdenado<Evento>> ListarAsync(PaginadoOrdenado<Evento> consulta)
        {
            var resultado = new PaginadoOrdenado<Evento>()
            {
                ItensPorPagina = consulta.ItensPorPagina,
                PaginaAtual = consulta.PaginaAtual,
                OrdemDirecao = consulta.OrdemDirecao,
                OrdemNome = consulta.OrdemNome,
            };

            /*var query = from item in Contexto.Esportes
                        select item;*/

            var query = Contexto.Eventos.AsQueryable();


            resultado.SetTotalDeLinhas(await query.CountAsync());

            if (consulta.OrdemDirecao == 0)
            {
                switch (consulta.OrdemNome)
                {
                    case "EventoDataInicio":
                        query = query.OrderBy(e => e.EventoDataInicio);
                        break;
                    case "EventoId":
                    default:
                        query = query.OrderBy(e => e.EventoId);
                        break;
                }
            }
            else
            {
                switch (consulta.OrdemNome)
                {
                    case "EventoDataInicio":
                        query = query.OrderByDescending(e => e.EventoDataInicio);
                        break;
                    case "EventoId":
                    default:
                        query = query.OrderByDescending(e => e.EventoId);
                        break;
                }
            }
            if (!(query is IOrderedQueryable))
            {
                query = query.OrderBy(e => e.EventoId);
            }

            query = query
                .Skip(resultado.ItensPorPagina * (resultado.PaginaAtual - 1))
                .Take(resultado.ItensPorPagina);

            resultado.Itens = query;

            return resultado;
        }

        public Task<List<Evento>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Evento> PegarAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
