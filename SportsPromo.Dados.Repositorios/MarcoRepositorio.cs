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
    public class MarcoRepositorio : BaseRepositorio<Marco>, IMarcoRepositorio
    {
        public MarcoRepositorio(ISportsPromoContexto contexto) : base(contexto)
        {
        }

        public override long Adicionar(Marco instancia)
        {
            Contexto.Marcos.Add(instancia);
            Contexto.SaveChanges();

            return instancia.MarcoId;
        }

        public Task<long> AdicionarAsync(Marco instancia)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AlterarAsync(Marco instancia)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarAsync(long id)
        {
            throw new NotImplementedException();
        }

        public PaginadoOrdenado<Marco> Listar(PaginadoOrdenado<Marco> consulta)
        {
            var resultado = new PaginadoOrdenado<Marco>()
            {
                ItensPorPagina = consulta.ItensPorPagina,
                PaginaAtual = consulta.PaginaAtual,
                OrdemDirecao = consulta.OrdemDirecao,
                OrdemNome = consulta.OrdemNome,
            };

            var query = Contexto.Marcos.AsQueryable();

            resultado.SetTotalDeLinhas(query.Count());

            if (consulta.OrdemDirecao == 0)
            {
                switch (consulta.OrdemNome)
                {
                    case "MarcoID":
                        query = query.OrderBy(e => e.MarcoId);
                        break;
                    case "MarcoLat":
                        query = query.OrderBy(e => e.MarcoLat);
                        break;
                    case "MarcoLon":
                    default:
                        query = query.OrderBy(e => e.MarcoLon);
                        break;
                }
            }
            else
            {
                switch (consulta.OrdemNome)
                {
                    case "MarcoID":
                        query = query.OrderByDescending(e => e.MarcoId);
                        break;
                    case "MarcoLon":
                        query = query.OrderByDescending(e => e.MarcoLon);
                        break;
                    case "MarcoLat":
                    default:
                        query = query.OrderByDescending(e => e.MarcoLat);
                        break;
                }
            }
            if (!(query is IOrderedQueryable))
            {
                query = query.OrderBy(e => e.MarcoId);
            }

            query = query
                .Skip(resultado.ItensPorPagina * (resultado.PaginaAtual - 1))
                .Take(resultado.ItensPorPagina);

            resultado.Itens = query;

            return resultado;
        }

        public async Task<PaginadoOrdenado<Marco>> ListarAsync(PaginadoOrdenado<Marco> consulta)
        {
            var resultado = new PaginadoOrdenado<Marco>()
            {
                ItensPorPagina = consulta.ItensPorPagina,
                PaginaAtual = consulta.PaginaAtual,
                OrdemDirecao = consulta.OrdemDirecao,
                OrdemNome = consulta.OrdemNome,
            };

            var query = Contexto.Marcos.AsQueryable();

            resultado.SetTotalDeLinhas(await query.CountAsync());

            if (consulta.OrdemDirecao == 0)
            {
                switch (consulta.OrdemNome)
                {
                    case "MarcoID":
                        query = query.OrderBy(e => e.MarcoId);
                        break;
                    case "MarcoLat":
                        query = query.OrderBy(e => e.MarcoLat);
                        break;
                    case "MarcoLon":
                    default:
                        query = query.OrderBy(e => e.MarcoLon);
                        break;
                }
            }
            else
            {
                switch (consulta.OrdemNome)
                {
                    case "MarcoID":
                        query = query.OrderByDescending(e => e.MarcoId);
                        break;
                    case "MarcoLon":
                        query = query.OrderByDescending(e => e.MarcoLon);
                        break;
                    case "MarcoLat":
                    default:
                        query = query.OrderByDescending(e => e.MarcoLat);
                        break;
                }
            }
            if (!(query is IOrderedQueryable))
            {
                query = query.OrderBy(e => e.MarcoId);
            }

            query = query
                .Skip(resultado.ItensPorPagina * (resultado.PaginaAtual - 1))
                .Take(resultado.ItensPorPagina);

            resultado.Itens = query;

            return resultado;
        }

        public Task<List<Marco>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PaginadoOrdenado<Esporte>> ListarAsync(PaginadoOrdenado<Esporte> consulta)
        {
            throw new NotImplementedException();
        }

        public Task<Marco> PegarAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
