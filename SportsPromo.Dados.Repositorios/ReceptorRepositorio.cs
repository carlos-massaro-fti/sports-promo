using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using SportsPromo.Comum.Dados;
using SportsPromo.Dominio.Modelos;
using SportsPromo.Interfaces.Dados.Contextos;
using SportsPromo.Interfaces.Dados.Repositorios;
using System.Collections.Generic;
using System;

namespace SportsPromo.Dados.Repositorios
{
    public class ReceptorRepositorio : BaseRepositorio<Receptor>, IReceptorRepositorio
    {
        public ReceptorRepositorio(ISportsPromoContexto contexto) : base(contexto)
        {
        }

        public override long Adicionar(Receptor instancia)
        {
            Contexto.Receptores.Add(instancia);

            Contexto.SaveChanges();

            return instancia.ReceptorId;
        }

        public async Task<long> AdicionarAsync(Receptor instancia)
        {
            Contexto.Receptores.Add(instancia);

            await Contexto.SaveChangesAsync();

            return instancia.ReceptorId;
        }

        public async Task<bool> AlterarAsync(Receptor instancia)
        {
            Contexto.Entry(instancia).State = System.Data.Entity.EntityState.Modified;

            var result = await Contexto.SaveChangesAsync() > 0;

            return result;
        }

        public Task<bool> DeletarAsync(long id)
        {
            throw new NotImplementedException();
        }

        public PaginadoOrdenado<Receptor> Listar(PaginadoOrdenado<Receptor> consulta)
        {

            var resultado = new PaginadoOrdenado<Receptor>()
            {
                ItensPorPagina = consulta.ItensPorPagina,
                PaginaAtual = consulta.PaginaAtual,
                OrdemDirecao = consulta.OrdemDirecao,
                OrdemNome = consulta.OrdemNome,
            };

            /*var query = from item in Contexto.Esportes
                        select item;*/

            var query = Contexto.Receptores.AsQueryable();


            resultado.SetTotalDeLinhas(query.Count());

            if (consulta.OrdemDirecao == 0)
            {
                switch (consulta.OrdemNome)
                {
                    case "ReceptorCodigo":
                        query = query.OrderBy(e => e.ReceptorCodigo);
                        break;
                    case "ReceptorId":
                    default:
                        query = query.OrderBy(e => e.ReceptorId);
                        break;
                }
            }
            else
            {
                switch (consulta.OrdemNome)
                {
                    case "ReceptorCodigo":
                        query = query.OrderByDescending(e => e.ReceptorCodigo);
                        break;
                    case "ReceptorId":
                    default:
                        query = query.OrderByDescending(e => e.ReceptorId);
                        break;
                }
            }
            if (!(query is IOrderedQueryable))
            {
                query = query.OrderBy(e => e.ReceptorId);
            }

            query = query
                .Skip(resultado.ItensPorPagina * (resultado.PaginaAtual - 1))
                .Take(resultado.ItensPorPagina);

            resultado.Itens = query;

            return resultado;
        }

        public async Task<PaginadoOrdenado<Receptor>> ListarAsync(PaginadoOrdenado<Receptor> consulta)
        {
            var resultado = new PaginadoOrdenado<Receptor>()
            {
                ItensPorPagina = consulta.ItensPorPagina,
                PaginaAtual = consulta.PaginaAtual,
                OrdemDirecao = consulta.OrdemDirecao,
                OrdemNome = consulta.OrdemNome,
            };

            /*var query = from item in Contexto.Esportes
                        select item;*/

            var query = Contexto.Receptores.AsQueryable();


            resultado.SetTotalDeLinhas(await query.CountAsync());

            if (consulta.OrdemDirecao == 0)
            {
                switch (consulta.OrdemNome)
                {
                    case "ReceptorCodigo":
                        query = query.OrderBy(e => e.ReceptorCodigo);
                        break;
                    case "ReceptorId":
                    default:
                        query = query.OrderBy(e => e.ReceptorId);
                        break;
                }
            }
            else
            {
                switch (consulta.OrdemNome)
                {
                    case "ReceptorCodigo":
                        query = query.OrderByDescending(e => e.ReceptorCodigo);
                        break;
                    case "ReceptorId":
                    default:
                        query = query.OrderByDescending(e => e.ReceptorId);
                        break;
                }
            }
            if (!(query is IOrderedQueryable))
            {
                query = query.OrderBy(e => e.ReceptorId);
            }

            query = query
                .Skip(resultado.ItensPorPagina * (resultado.PaginaAtual - 1))
                .Take(resultado.ItensPorPagina);

            resultado.Itens = query;

            return resultado;
        }

        public async Task<List<Receptor>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Receptor> PegarAsync(long id)
        {
            var resultado = await Contexto.Receptores.FindAsync(id);

            return resultado;
        }
    }
}
