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

namespace SportsPromo.App.Core.Manipuladores
{
    public class EsporteManipulador : IEsporteManipulador
    {
        protected IEsporteServico EsporteServico { get; }


        public EsporteManipulador(IEsporteServico esporteServico)
        {
            EsporteServico = esporteServico;
        }
        public long Adicionar(EsporteApp instancia)
        {
            var modelInstancia = new Esporte();

            modelInstancia.EsporteNome = instancia.Nome;

            var result = EsporteServico.Adicionar(modelInstancia);

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
                Itens = resultadoDominio.Itens.Select(e => new EsporteApp()
                {
                    Id = e.EsporteId,
                    Nome = e.EsporteNome
                }),
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
                Itens = resultadoDominio.Itens.Select(e => new EsporteApp()
                {
                    Id = e.EsporteId,
                    Nome = e.EsporteNome
                }),
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

        public Task<List<EsporteApp>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EsporteApp> PegarAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AlterarAsync(EsporteApp instancia)
        {
            throw new NotImplementedException();
        }

        public Task<long> AdicionarAsync(EsporteApp instancia)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ValidationResult>> ValidarAsync(EsporteApp instancia)
        {
            throw new NotImplementedException();
        }
    }
}
