using SportsPromo.App.Interfaces.Manipuladores;
using SportsPromo.App.Core.Modelos;
using SportsPromo.Dominio.Modelos;
using SportsPromo.Interfaces.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsPromo.Comum.Dados;
using AutoMapper;

namespace SportsPromo.App.Core.Manipuladores
{
    public class CategoriaManipulador : ICategoriaManipulador
    {
        protected ICategoriaServico CategoriaServico { get;}
        protected IMapper Mapper { get; }

        public CategoriaManipulador(ICategoriaServico categoriaServico, IMapper mapper)
        {
            CategoriaServico = categoriaServico;
            Mapper = mapper;
        }
        public long Adicionar(CategoriaApp instancia)
        {
            var modelDominio = Mapper.Map<Categoria>(instancia);

            var result = CategoriaServico.Adicionar(modelDominio);

            return result;
        }

        public async Task<long> AdicionarAsync(CategoriaApp instancia)
        {
            var instanciaDominio = Mapper.Map<Categoria>(instancia);

            var resultado = await CategoriaServico.AdicionarAsync(instanciaDominio);

            return resultado;
        }

        public bool Alterar(CategoriaApp instancia)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AlterarAsync(CategoriaApp instancia)
        {
            throw new NotImplementedException();
        }

        public bool Deletar(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarAsync(long id)
        {
            throw new NotImplementedException();
        }

        public PaginadoOrdenado<CategoriaApp> Listar(PaginadoOrdenado<CategoriaApp> consulta)
        {
            var consultaDominio = new PaginadoOrdenado<Categoria>()
            {
                ItensPorPagina = consulta.ItensPorPagina,
                PaginaAtual = consulta.PaginaAtual,
                OrdemDirecao = consulta.OrdemDirecao,
            };

            switch (consulta.OrdemNome)
            {
                case "Id":
                    consultaDominio.OrdemNome = "CategoriaId";
                    break;
                case "Nome":
                    consultaDominio.OrdemNome = "CategoriaNome";
                    break;
            }

            var resultadoDominio = CategoriaServico.Listar(consultaDominio);

            var resultado = new PaginadoOrdenado<CategoriaApp>()
            {
                ItensPorPagina = resultadoDominio.ItensPorPagina,
                ContagemDePaginas = resultadoDominio.ContagemDePaginas,
                ContagemDeLinhas = resultadoDominio.ContagemDeLinhas,
                PaginaAtual = resultadoDominio.PaginaAtual,
                Itens = Mapper.Map<List<CategoriaApp>>(resultadoDominio.Itens),
                OrdemDirecao = resultadoDominio.OrdemDirecao
            };

            switch (resultadoDominio.OrdemNome)
            {
                case "CategoriaId":
                    resultado.OrdemNome = "Id";
                    break;
                case "CategoriaNome":
                    resultado.OrdemNome = "Nome";
                    break;
            }

            return resultado;
        }

        public List<CategoriaApp> Listar()
        {
            throw new NotImplementedException();
        }

        public async Task<PaginadoOrdenado<CategoriaApp>> ListarAsync(PaginadoOrdenado<CategoriaApp> consulta)
        {
            var consultaDominio = new PaginadoOrdenado<Categoria>()
            {
                ItensPorPagina = consulta.ItensPorPagina,
                PaginaAtual = consulta.PaginaAtual,
                OrdemDirecao = consulta.OrdemDirecao,
            };

            switch (consulta.OrdemNome)
            {
                case "Id":
                    consultaDominio.OrdemNome = "CategoriaId";
                    break;
                case "Nome":
                    consultaDominio.OrdemNome = "CategoriaNome";
                    break;
            }

            var resultadoDominio = await CategoriaServico.ListarAsync(consultaDominio);

            var resultado = new PaginadoOrdenado<CategoriaApp>()
            {
                ItensPorPagina = resultadoDominio.ItensPorPagina,
                ContagemDePaginas = resultadoDominio.ContagemDePaginas,
                ContagemDeLinhas = resultadoDominio.ContagemDeLinhas,
                PaginaAtual = resultadoDominio.PaginaAtual,
                OrdemDirecao = resultadoDominio.OrdemDirecao,
                Itens = Mapper.Map<List<CategoriaApp>>(resultadoDominio.Itens)
            };

            switch (resultadoDominio.OrdemNome)
            {
                case "CategoriaId":
                    resultado.OrdemNome = "Id";
                    break;
                case "CategoriaNome":
                    resultado.OrdemNome = "Nome";
                    break;
            }

            return resultado;
        }

        public Task<List<CategoriaApp>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public CategoriaApp Pegar(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoriaApp> PegarAsync(long id)
        {
            var resultadoDominio = await CategoriaServico.PegarAsync(id);

            var resultado = Mapper.Map<CategoriaApp>(resultadoDominio);

            return resultado;
        }

        public IEnumerable<ValidationResult> Validar(CategoriaApp instancia)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ValidationResult>> ValidarAsync(CategoriaApp instancia)
        {
            throw new NotImplementedException();
        }
    }
}
