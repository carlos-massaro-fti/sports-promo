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
    public class EquipeRepositorio : BaseRepositorio<Equipe>, IEquipeRepositorio
    {
        public EquipeRepositorio(ISportsPromoContexto contexto) : base(contexto)
        {
        }

        public override long Adicionar(Equipe instancia)
        {
            Contexto.Equipes.Add(instancia);

            Contexto.SaveChanges();

            return instancia.EquipeId;
        }
        public async Task<long> AdicionarAsync(Equipe instancia)
        {
            Contexto.Equipes.Add(instancia);

            await Contexto.SaveChangesAsync();

            return instancia.EquipeId;
        }

        public async Task<bool> AlterarAsync(Equipe instancia)
        {
            Contexto.Entry(instancia).State = System.Data.Entity.EntityState.Modified;

            var result = await Contexto.SaveChangesAsync() > 0;

            return result;
        }

        public Task<bool> DeletarAsync(long id)
        {
            throw new NotImplementedException();
        }

        public PaginadoOrdenado<Equipe> Listar(PaginadoOrdenado<Equipe> consulta)
        {
            var resultado = new PaginadoOrdenado<Equipe>()
            {
                ItensPorPagina = consulta.ItensPorPagina,
                PaginaAtual = consulta.PaginaAtual,
                OrdemDirecao = consulta.OrdemDirecao,
                OrdemNome = consulta.OrdemNome,
            };

            var query = Contexto.Equipes.AsQueryable();

            resultado.SetTotalDeLinhas(query.Count());

            if (consulta.OrdemDirecao == 0)
            {
                switch (consulta.OrdemNome)
                {
                    case "EquipeNome":
                        query = query.OrderBy(e => e.EquipeNome);
                        break;
                    case "EquipeId":
                    default:
                        query = query.OrderBy(e => e.EquipeId);
                        break;
                }
            }
            else
            {
                switch (consulta.OrdemNome)
                {
                    case "EquipeNome":
                        query = query.OrderByDescending(e => e.EquipeNome);
                        break;
                    case "EquipeId":
                    default:
                        query = query.OrderByDescending(e => e.EquipeId);
                        break;
                }
            }
            if (!(query is IOrderedQueryable))
            {
                query = query.OrderBy(e => e.EquipeId);
            }

            query = query
                .Skip(resultado.ItensPorPagina * (resultado.PaginaAtual - 1))
                .Take(resultado.ItensPorPagina);

            resultado.Itens = query;

            return resultado;
        }

        public async Task<PaginadoOrdenado<Equipe>> ListarAsync(PaginadoOrdenado<Equipe> consulta)
        {
            var resultado = new PaginadoOrdenado<Equipe>()
            {
                ItensPorPagina = consulta.ItensPorPagina,
                PaginaAtual = consulta.PaginaAtual,
                OrdemDirecao = consulta.OrdemDirecao,
                OrdemNome = consulta.OrdemNome,
            };
            var query = Contexto.Equipes.AsQueryable();


            resultado.SetTotalDeLinhas(await query.CountAsync());

            if (consulta.OrdemDirecao == 0)
            {
                switch (consulta.OrdemNome)
                {
                    case "EquipeNome":
                        query = query.OrderBy(e => e.EquipeNome);
                        break;
                    case "EquipeId":
                    default:
                        query = query.OrderBy(e => e.EquipeId);
                        break;
                }
            }
            else
            {
                switch (consulta.OrdemNome)
                {
                    case "EquipeNome":
                        query = query.OrderByDescending(e => e.EquipeNome);
                        break;
                    case "EquipeId":
                    default:
                        query = query.OrderByDescending(e => e.EquipeId);
                        break;
                }
            }
            if (!(query is IOrderedQueryable))
            {
                query = query.OrderBy(e => e.EquipeId);
            }

            query = query
                .Skip(resultado.ItensPorPagina * (resultado.PaginaAtual - 1))
                .Take(resultado.ItensPorPagina);

            resultado.Itens = query;

            return resultado;
        }

        public Task<List<Equipe>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Equipe> PegarAsync(long id)
        {
            var resultado = await Contexto.Equipes.FindAsync(id);

            return resultado;
        }
    }
}
