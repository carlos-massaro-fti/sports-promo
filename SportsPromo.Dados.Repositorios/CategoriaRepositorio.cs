using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using SportsPromo.Comum.Dados;
using SportsPromo.Dominio.Modelos;
using SportsPromo.Interfaces.Dados.Contextos;
using SportsPromo.Interfaces.Dados.Repositorios;
namespace SportsPromo.Dados.Repositorios
{
    public class CategoriaRepositorio : BaseRepositorio<Categoria>, ICategoriaRepositorio
    {
        public CategoriaRepositorio(ISportsPromoContexto contexto) : base(contexto)
        {
        }

        public override long Adicionar(Categoria instancia)
        {
            Contexto.Categorias.Add(instancia);

            Contexto.SaveChanges();

            return instancia.CategoriaId;
        }

        public async Task<long> AdicionarAsync(Categoria instancia)
        {
            Contexto.Categorias.Add(instancia);

            await Contexto.SaveChangesAsync();

            return instancia.CategoriaId;
        }

        public Task<bool> AlterarAsync(Categoria instancia)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarAsync(long id)
        {
            throw new NotImplementedException();
        }

        public PaginadoOrdenado<Categoria> Listar(PaginadoOrdenado<Categoria> consulta)
        {
            var resultado = new PaginadoOrdenado<Categoria>()
            {
                ItensPorPagina = consulta.ItensPorPagina,
                PaginaAtual = consulta.PaginaAtual,
                OrdemDirecao = consulta.OrdemDirecao,
                OrdemNome = consulta.OrdemNome,
            };

            /*var query = from item in Contexto.Esportes
                        select item;*/

            var query = Contexto.Categorias.AsQueryable();


            resultado.SetTotalDeLinhas(query.Count());

            if (consulta.OrdemDirecao == 0)
            {
                switch (consulta.OrdemNome)
                {
                    case "CategoriaNome":
                        query = query.OrderBy(e => e.CategoriaNome);
                        break;
                    case "CategoriaId":
                    default:
                        query = query.OrderBy(e => e.CategoriaId);
                        break;
                }
            }
            else
            {
                switch (consulta.OrdemNome)
                {
                    case "CategoriaNome":
                        query = query.OrderByDescending(e => e.CategoriaNome);
                        break;
                    case "CategoriaId":
                    default:
                        query = query.OrderByDescending(e => e.CategoriaId);
                        break;
                }
            }
            if (!(query is IOrderedQueryable))
            {
                query = query.OrderBy(e => e.CategoriaId);
            }

            query = query
                .Skip(resultado.ItensPorPagina * (resultado.PaginaAtual - 1))
                .Take(resultado.ItensPorPagina);

            resultado.Itens = query;

            return resultado;
        }

        public async Task<PaginadoOrdenado<Categoria>> ListarAsync(PaginadoOrdenado<Categoria> consulta)
        {
            var resultado = new PaginadoOrdenado<Categoria>()
            {
                ItensPorPagina = consulta.ItensPorPagina,
                PaginaAtual = consulta.PaginaAtual,
                OrdemDirecao = consulta.OrdemDirecao,
                OrdemNome = consulta.OrdemNome,
            };

            /*var query = from item in Contexto.Esportes
                        select item;*/

            var query = Contexto.Categorias.AsQueryable();


            resultado.SetTotalDeLinhas(await query.CountAsync());

            if (consulta.OrdemDirecao == 0)
            {
                switch (consulta.OrdemNome)
                {
                    case "CategoriaNome":
                        query = query.OrderBy(e => e.CategoriaNome);
                        break;
                    case "CategoriaId":
                    default:
                        query = query.OrderBy(e => e.CategoriaId);
                        break;
                }
            }
            else
            {
                switch (consulta.OrdemNome)
                {
                    case "CategoriaNome":
                        query = query.OrderByDescending(e => e.CategoriaNome);
                        break;
                    case "CategoriaId":
                    default:
                        query = query.OrderByDescending(e => e.CategoriaId);
                        break;
                }
            }
            if (!(query is IOrderedQueryable))
            {
                query = query.OrderBy(e => e.CategoriaId);
            }

            query = query
                .Skip(resultado.ItensPorPagina * (resultado.PaginaAtual - 1))
                .Take(resultado.ItensPorPagina);

            resultado.Itens = query;

            return resultado;
        }

        public Task<List<Categoria>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Categoria> PegarAsync(long id)
        {
            var resultado = await Contexto.Categorias.FindAsync(id);
            return resultado;
        }

    }
}
