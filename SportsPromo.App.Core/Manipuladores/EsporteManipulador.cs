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
    public class EsporteManipulador : IEsporteManipulador
    {
        protected IEsporteServico EsporteServico { get; }
        protected IMapper Mapper { get; }


        public EsporteManipulador(IEsporteServico esporteServico, IMapper mapper)
        {
            EsporteServico = esporteServico;
            Mapper = mapper;
        }
        public long Adicionar(EsporteApp instancia)
        {
            var modelDominio = Mapper.Map<Esporte>(instancia);

            var result = EsporteServico.Adicionar(modelDominio);

            return result;
        }

        public bool Alterar(EsporteApp instancia)
        {
            throw new NotImplementedException();
        }

        public bool Deletar(long id)
        {
            throw new NotImplementedException();
        }

        public List<EsporteApp> Listar()
        {
            throw new NotImplementedException();
        }

        public EsporteApp Pegar(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ValidationResult> Validar(EsporteApp instancia)
        {
            throw new NotImplementedException();
        }



        public PaginadoOrdenado<EsporteApp> Listar(PaginadoOrdenado<EsporteApp> consulta)
        {
            var consultaDominio = new PaginadoOrdenado<Esporte>()
            {
                ItensPorPagina = consulta.ItensPorPagina,
                PaginaAtual = consulta.PaginaAtual,
                OrdemDirecao = consulta.OrdemDirecao,
            };

            switch (consulta.OrdemNome)
            {
                case "Id":
                    consultaDominio.OrdemNome = "EsporteId";
                    break;
                case "Nome":
                    consultaDominio.OrdemNome = "EsporteNome";
                    break;
            }

            var resultadoDominio = EsporteServico.Listar(consultaDominio);

            var resultado = new PaginadoOrdenado<EsporteApp>()
            {
                ItensPorPagina = resultadoDominio.ItensPorPagina,
                ContagemDePaginas = resultadoDominio.ContagemDePaginas,
                ContagemDeLinhas = resultadoDominio.ContagemDeLinhas,
                PaginaAtual = resultadoDominio.PaginaAtual,
                Itens = Mapper.Map<List<EsporteApp>>(resultadoDominio.Itens),
                OrdemDirecao = resultadoDominio.OrdemDirecao
            };

            switch (resultadoDominio.OrdemNome)
            {
                case "EsporteId":
                    resultado.OrdemNome = "Id";
                    break;
                case "EsporteNome":
                    resultado.OrdemNome = "Nome";
                    break;
            }

            return resultado;
        }

        public async Task<PaginadoOrdenado<EsporteApp>> ListarAsync(PaginadoOrdenado<EsporteApp> consulta)
        {

            var consultaDominio = new PaginadoOrdenado<Esporte>()
            {
                ItensPorPagina = consulta.ItensPorPagina,
                PaginaAtual = consulta.PaginaAtual,
                OrdemDirecao = consulta.OrdemDirecao,
            };

            switch (consulta.OrdemNome)
            {
                case "Id":
                    consultaDominio.OrdemNome = "EsporteId";
                    break;
                case "Nome":
                    consultaDominio.OrdemNome = "EsporteNome";
                    break;
            }

            var resultadoDominio = await EsporteServico.ListarAsync(consultaDominio);

            var resultado = new PaginadoOrdenado<EsporteApp>()
            {
                ItensPorPagina = resultadoDominio.ItensPorPagina,
                ContagemDePaginas = resultadoDominio.ContagemDePaginas,
                ContagemDeLinhas = resultadoDominio.ContagemDeLinhas,
                PaginaAtual = resultadoDominio.PaginaAtual,
                OrdemDirecao = resultadoDominio.OrdemDirecao,
                Itens = Mapper.Map<List<EsporteApp>>(resultadoDominio.Itens)
            };

            switch (resultadoDominio.OrdemNome)
            {
                case "EsporteId":
                    resultado.OrdemNome = "Id";
                    break;
                case "EsporteNome":
                    resultado.OrdemNome = "Nome";
                    break;
            }

            return resultado;

        }

        public Task<List<EsporteApp>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<EsporteApp> PegarAsync(long id)
        {
            var resultadoDominio = await EsporteServico.PegarAsync(id);

            var resultado = Mapper.Map<EsporteApp>(resultadoDominio);

            return resultado;
        }

        public Task<bool> DeletarAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AlterarAsync(EsporteApp instancia)
        {
            var instanciaDominio = Mapper.Map<Esporte>(instancia);

            var resultado = await EsporteServico.AlterarAsync(instanciaDominio);

            return resultado;
        }

        public async Task<long> AdicionarAsync(EsporteApp instancia)
        {
            var instanciaDominio = Mapper.Map<Esporte>(instancia);

            var resultado = await EsporteServico.AdicionarAsync(instanciaDominio);

            return resultado;
        }

        public Task<IEnumerable<ValidationResult>> ValidarAsync(EsporteApp instancia)
        {
            throw new NotImplementedException();
        }
    }
}
