using SportsPromo.App.Interfaces.Manipuladores;
using SportsPromo.App.Modelos;
using SportsPromo.Comum.Dados;
using SportsPromo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.App.Core.Manipuladores
{
    public class MarcoManipulador : IMarcoManipulador
    {
        protected IMarcoManipulador MarcoServico { get; }

        public MarcoManipulador(IMarcoManipulador marcoServico)
        {
            MarcoServico = marcoServico;
        }
        public long Adicionar(MarcoApp instancia)
        {
            throw new NotImplementedException();
            //var modelInstancia = new Marco();

            //modelInstancia.MarcoId= instancia.Id;

            //var result = MarcoServico.Adicionar(modelInstancia));

            //return result;
        }

        public bool Alterar(MarcoApp instancia)
        {
            throw new NotImplementedException();
        }

        public bool Deletar(long id)
        {
            throw new NotImplementedException();
        }

        public List<MarcoApp> Listar()
        {
            throw new NotImplementedException();
        }

        public MarcoApp Pegar(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ValidationResult> Validar(MarcoApp instancia)
        {
            throw new NotImplementedException();
        }



        public PaginadoOrdenado<MarcoApp> Listar(PaginadoOrdenado<MarcoApp> consulta)
        {
            //var consultaDominio = new PaginadoOrdenado<Esporte>()
            //{
            //    ItensPorPagina = consulta.ItensPorPagina,
            //    PaginaAtual = consulta.PaginaAtual,
            //    OrdemDirecao = consulta.OrdemDirecao,
            //};

            //switch (consulta.OrdemNome)
            //{
            //    case "Id":
            //        consultaDominio.OrdemNome = "EsporteId";
            //        break;
            //    case "Nome":
            //        consultaDominio.OrdemNome = "EsporteNome";
            //        break;
            //}

            //var resultadoDominio = EsporteServico.Listar(consultaDominio);

            //var resultado = new PaginadoOrdenado<MarcoApp>()
            //{
            //    ItensPorPagina = resultadoDominio.ItensPorPagina,
            //    ContagemDePaginas = resultadoDominio.ContagemDePaginas,
            //    ContagemDeLinhas = resultadoDominio.ContagemDeLinhas,
            //    PaginaAtual = resultadoDominio.PaginaAtual,
            //    Itens = resultadoDominio.Itens.Select(e => new MarcoApp()
            //    {
            //        Id = e.EsporteId,
            //        Nome = e.EsporteNome
            //    }),
            //    OrdemDirecao = resultadoDominio.OrdemDirecao
            //};

            //switch (resultadoDominio.OrdemNome)
            //{
            //    case "EsporteId":
            //        resultado.OrdemNome = "Id";
            //        break;
            //    case "EsporteNome":
            //        resultado.OrdemNome = "Nome";
            //        break;
            //}

            throw new NotImplementedException();
        }

        //public async Task<PaginadoOrdenado<MarcoApp>> ListarAsync(PaginadoOrdenado<MarcoApp> consulta)
        //{

        //    //var consultaDominio = new PaginadoOrdenado<Esporte>()
        //    //{
        //    //    ItensPorPagina = consulta.ItensPorPagina,
        //    //    PaginaAtual = consulta.PaginaAtual,
        //    //    OrdemDirecao = consulta.OrdemDirecao,
        //    //};

        //    //switch (consulta.OrdemNome)
        //    //{
        //    //    case "Id":
        //    //        consultaDominio.OrdemNome = "EsporteId";
        //    //        break;
        //    //    case "Nome":
        //    //        consultaDominio.OrdemNome = "EsporteNome";
        //    //        break;
        //    //}

        //    //var resultadoDominio = await EsporteServico.ListarAsync(consultaDominio);

        //    //var resultado = new PaginadoOrdenado<MarcoApp>()
        //    //{
        //    //    ItensPorPagina = resultadoDominio.ItensPorPagina,
        //    //    ContagemDePaginas = resultadoDominio.ContagemDePaginas,
        //    //    ContagemDeLinhas = resultadoDominio.ContagemDeLinhas,
        //    //    PaginaAtual = resultadoDominio.PaginaAtual,
        //    //    Itens = resultadoDominio.Itens.Select(e => new MarcoApp()
        //    //    {
        //    //        Id = e.EsporteId,
        //    //        Nome = e.EsporteNome
        //    //    }),
        //    //    OrdemDirecao = resultadoDominio.OrdemDirecao
        //    //};

        //    //switch (resultadoDominio.OrdemNome)
        //    //{
        //    //    case "EsporteId":
        //    //        resultado.OrdemNome = "Id";
        //    //        break;
        //    //    case "EsporteNome":
        //    //        resultado.OrdemNome = "Nome";
        //    //        break;
        //    //}

        //    throw new NotImplementedException();

        //}

        public Task<List<MarcoApp>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MarcoApp> PegarAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AlterarAsync(MarcoApp instancia)
        {
            throw new NotImplementedException();
        }

        public Task<long> AdicionarAsync(MarcoApp instancia)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ValidationResult>> ValidarAsync(MarcoApp instancia)
        {
            throw new NotImplementedException();
        }


        List<MarcoApp> IMarcoManipulador.Listar()
        {
            throw new NotImplementedException();
        }

        MarcoApp IMarcoManipulador.Pegar(long id)
        {
            throw new NotImplementedException();
        }



        public Task<IEnumerable<ValidationResult>> ValidationResults(MarcoApp instancia)
        {
            throw new NotImplementedException();
        }

        public Task<PaginadoOrdenado<MarcoApp>> ListarAsync(PaginadoOrdenado<MarcoApp> consulta)
        {
            throw new NotImplementedException();
        }
    }

}
