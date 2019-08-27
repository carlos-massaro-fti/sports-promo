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
using SportsPromo.App.Modelos;

namespace SportsPromo.App.Core.Manipuladores
{
   public  class ReceptorManipulador : IReceptorManipulador
    {
        protected IReceptorServico ReceptorServico { get; }
        protected IMapper Mapper { get; }


        public ReceptorManipulador(IReceptorServico receptorServico, IMapper mapper)
        {
            ReceptorServico = receptorServico;
            Mapper = mapper;
        }
        public long Adicionar(ReceptorApp instancia)
        {
            var modelDominio = Mapper.Map<Receptor>(instancia);

            var result = ReceptorServico.Adicionar(modelDominio);

            return result;
        }

        public bool Alterar(ReceptorApp instancia)
        {
            throw new NotImplementedException();
        }

        public bool Deletar(long id)
        {
            throw new NotImplementedException();
        }

        public List<ReceptorApp> Listar()
        {
            throw new NotImplementedException();
        }

        public ReceptorApp Pegar(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ValidationResult> Validar(ReceptorApp instancia)
        {
            throw new NotImplementedException();
        }



        public PaginadoOrdenado<ReceptorApp> Listar(PaginadoOrdenado<ReceptorApp> consulta)
        {
            var consultaDominio = new PaginadoOrdenado<Receptor>()
            {
                ItensPorPagina = consulta.ItensPorPagina,
                PaginaAtual = consulta.PaginaAtual,
                OrdemDirecao = consulta.OrdemDirecao,
            };

            switch (consulta.OrdemNome)
            {
                case "Id":
                    consultaDominio.OrdemNome = "ReceptorId";
                    break;
                case "Codigo":
                    consultaDominio.OrdemNome = "ReceptorCodigo";
                    break;
            }

            var resultadoDominio = ReceptorServico.Listar(consultaDominio);

            var resultado = new PaginadoOrdenado<ReceptorApp>()
            {
                ItensPorPagina = resultadoDominio.ItensPorPagina,
                ContagemDePaginas = resultadoDominio.ContagemDePaginas,
                ContagemDeLinhas = resultadoDominio.ContagemDeLinhas,
                PaginaAtual = resultadoDominio.PaginaAtual,
                Itens = Mapper.Map<List<ReceptorApp>>(resultadoDominio.Itens),
                OrdemDirecao = resultadoDominio.OrdemDirecao
            };

            switch (resultadoDominio.OrdemNome)
            {
                case "ReceptorId":
                    resultado.OrdemNome = "Id";
                    break;
                case "ReceptorCodigo":
                    resultado.OrdemNome = "Codigo";
                    break;
            }

            return resultado;
        }

        public async Task<PaginadoOrdenado<ReceptorApp>> ListarAsync(PaginadoOrdenado<ReceptorApp> consulta)
        {

            var consultaDominio = new PaginadoOrdenado<Receptor>()
            {
                ItensPorPagina = consulta.ItensPorPagina,
                PaginaAtual = consulta.PaginaAtual,
                OrdemDirecao = consulta.OrdemDirecao,
            };

            switch (consulta.OrdemNome)
            {
                case "Id":
                    consultaDominio.OrdemNome = "ReceptorId";
                    break;
                case "Codigo":
                    consultaDominio.OrdemNome = "ReceptorCodigo";
                    break;
            }

            var resultadoDominio = await ReceptorServico.ListarAsync(consultaDominio);

            var resultado = new PaginadoOrdenado<ReceptorApp>()
            {
                ItensPorPagina = resultadoDominio.ItensPorPagina,
                ContagemDePaginas = resultadoDominio.ContagemDePaginas,
                ContagemDeLinhas = resultadoDominio.ContagemDeLinhas,
                PaginaAtual = resultadoDominio.PaginaAtual,
                OrdemDirecao = resultadoDominio.OrdemDirecao,
                Itens = Mapper.Map<List<ReceptorApp>>(resultadoDominio.Itens)
            };

            switch (resultadoDominio.OrdemNome)
            {
                case "ReceptorId":
                    resultado.OrdemNome = "Id";
                    break;
                case "ReceptorCodigo":
                    resultado.OrdemNome = "Codigo";
                    break;
            }

            return resultado;

        }

        public Task<List<ReceptorApp>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ReceptorApp> PegarAsync(long id)
        {
            var resultadoDominio = await ReceptorServico.PegarAsync(id);

            var resultado = Mapper.Map<ReceptorApp>(resultadoDominio);

            return resultado;
        }

        public Task<bool> DeletarAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AlterarAsync(ReceptorApp instancia)
        {
            throw new NotImplementedException();
        }

        public async Task<long> AdicionarAsync(ReceptorApp instancia)
        {
            var instanciaDominio = Mapper.Map<Receptor>(instancia);

            var resultado = await ReceptorServico.AdicionarAsync(instanciaDominio);

            return resultado;
        }

        public Task<IEnumerable<ValidationResult>> ValidarAsync(ReceptorApp instancia)
        {
            throw new NotImplementedException();
        }
    }
}
