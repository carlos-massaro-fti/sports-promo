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
    public class ChecagemRepositorio : BaseRepositorio<Checagem>, IChecagemRepositorio
    {
        public ChecagemRepositorio(ISportsPromoContexto contexto) : base(contexto)
        {
        }

        public override long Adicionar(Checagem instancia)
        {
            Contexto.Checagems.Add(instancia);

            Contexto.SaveChanges();

            return instancia.ChecagemId;
        }
        public async Task<long> AdicionarAsync(Checagem instancia)
        {
            Contexto.Checagems.Add(instancia);

            await Contexto.SaveChangesAsync();

            return instancia.ChecagemId;
        }

        public async Task<bool> AlterarAsync(Checagem instancia)
        {
            Contexto.Entry(instancia).State = System.Data.Entity.EntityState.Modified;

            var result = await Contexto.SaveChangesAsync() > 0;

            return result;
        }

        public Task<bool> DeletarAsync(long id)
        {
            throw new NotImplementedException();
        }

        public PaginadoOrdenado<Checagem> Listar(PaginadoOrdenado<Checagem> consulta)
        {
            var resultado = new PaginadoOrdenado<Checagem>()
            {
                ItensPorPagina = consulta.ItensPorPagina,
                PaginaAtual = consulta.PaginaAtual,
                OrdemDirecao = consulta.OrdemDirecao,
                OrdemNome = consulta.OrdemNome,
            };

            var query = Contexto.Checagems.AsQueryable();
            
            resultado.SetTotalDeLinhas(query.Count());

            if (consulta.OrdemDirecao == 0)
            {
                switch (consulta.OrdemNome)
                {
                    case "ChecagemRfid":
                        query = query.OrderBy(e => e.ChecagemRfid);
                        break;
                    case "ChecagemId":
                    default:
                        query = query.OrderBy(e => e.ChecagemId);
                        break;
                }
            }
            else
            {
                switch (consulta.OrdemNome)
                {
                    case "ChecagemRfid":
                        query = query.OrderByDescending(e => e.ChecagemRfid);
                        break;
                    case "ChecagemId":
                    default:
                        query = query.OrderByDescending(e => e.ChecagemId);
                        break;
                }
            }
            if (!(query is IOrderedQueryable))
            {
                query = query.OrderBy(e => e.ChecagemId);
            }

            query = query
                .Skip(resultado.ItensPorPagina * (resultado.PaginaAtual - 1))
                .Take(resultado.ItensPorPagina);

            resultado.Itens = query;

            return resultado;
        }

        public async Task<PaginadoOrdenado<Checagem>> ListarAsync(PaginadoOrdenado<Checagem> consulta)
        {
            var resultado = new PaginadoOrdenado<Checagem>()
            {
                ItensPorPagina = consulta.ItensPorPagina,
                PaginaAtual = consulta.PaginaAtual,
                OrdemDirecao = consulta.OrdemDirecao,
                OrdemNome = consulta.OrdemNome,
            };
            var query = Contexto.Checagems.AsQueryable();


            resultado.SetTotalDeLinhas(await query.CountAsync());

            if (consulta.OrdemDirecao == 0)
            {
                switch (consulta.OrdemNome)
                {
                    case "ChecagemRfid":
                        query = query.OrderBy(e => e.ChecagemRfid);
                        break;
                    case "ChecagemId":
                    default:
                        query = query.OrderBy(e => e.ChecagemId);
                        break;
                }
            }
            else
            {
                switch (consulta.OrdemNome)
                {
                    case "ChecagemRfid":
                        query = query.OrderByDescending(e => e.ChecagemRfid);
                        break;
                    case "ChecagemId":
                    default:
                        query = query.OrderByDescending(e => e.ChecagemId);
                        break;
                }
            }
            if (!(query is IOrderedQueryable))
            {
                query = query.OrderBy(e => e.ChecagemId);
            }

            query = query
                .Skip(resultado.ItensPorPagina * (resultado.PaginaAtual - 1))
                .Take(resultado.ItensPorPagina);

            resultado.Itens = query;

            return resultado;
        }

        public Task<List<Checagem>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Checagem> PegarAsync(long id)
        {
            var resultado = await Contexto.Checagems.FindAsync(id);

            return resultado;
        }
    }
}
