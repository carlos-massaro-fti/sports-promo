using AutoMapper;
using SportsPromo.App.Interfaces.Manipuladores;
using SportsPromo.App.Modelos;
using SportsPromo.Comum.Dados;
using SportsPromo.Dominio.Modelos;
using SportsPromo.Dominio.Servicos;
using SportsPromo.Interfaces.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.App.Core.Manipuladores
{
    public class ChecagemManipulador : IChecagemManipulador
    {
        protected IChecagemServico ChecagemServico { get; }
        protected IMapper Mapper { get; }


        public ChecagemManipulador(IChecagemServico checagemServico, IMapper mapper)
        {
            ChecagemServico = checagemServico;
            Mapper = mapper;
        }
        public long Adicionar(ChecagemApp instancia)
        {
            var modelDominio = Mapper.Map<Checagem>(instancia);

            var result = ChecagemServico.Adicionar(modelDominio);

            return result;
        }

        public bool Alterar(ChecagemApp instancia)
        {
            throw new NotImplementedException();
        }

        public bool Deletar(long id)
        {
            throw new NotImplementedException();
        }

        public List<ChecagemApp> Listar()
        {
            throw new NotImplementedException();
        }

        public ChecagemApp Pegar(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ValidationResult> Validar(ChecagemApp instancia)
        {
            throw new NotImplementedException();
        }



        public PaginadoOrdenado<ChecagemApp> Listar(PaginadoOrdenado<ChecagemApp> consulta)
        {
            var consultaDominio = new PaginadoOrdenado<Checagem>()
            {
                ItensPorPagina = consulta.ItensPorPagina,
                PaginaAtual = consulta.PaginaAtual,
                OrdemDirecao = consulta.OrdemDirecao,
            };

            switch (consulta.OrdemNome)
            {
                case "Id":
                    consultaDominio.OrdemNome = "ChecagemId";
                    break;
                case "Rfid":
                    consultaDominio.OrdemNome = "ChecagemRfid";
                    break;
            }

            var resultadoDominio = ChecagemServico.Listar(consultaDominio);

            var resultado = new PaginadoOrdenado<ChecagemApp>()
            {
                ItensPorPagina = resultadoDominio.ItensPorPagina,
                ContagemDePaginas = resultadoDominio.ContagemDePaginas,
                ContagemDeLinhas = resultadoDominio.ContagemDeLinhas,
                PaginaAtual = resultadoDominio.PaginaAtual,
                Itens = Mapper.Map<List<ChecagemApp>>(resultadoDominio.Itens),
                OrdemDirecao = resultadoDominio.OrdemDirecao
            };

            switch (resultadoDominio.OrdemNome)
            {
                case "ChecagemId":
                    resultado.OrdemNome = "Id";
                    break;
                case "ChecagemRfid":
                    resultado.OrdemNome = "Rfid";
                    break;
            }

            return resultado;
        }

        public async Task<PaginadoOrdenado<ChecagemApp>> ListarAsync(PaginadoOrdenado<ChecagemApp> consulta)
        {

            var consultaDominio = new PaginadoOrdenado<Checagem>()
            {
                ItensPorPagina = consulta.ItensPorPagina,
                PaginaAtual = consulta.PaginaAtual,
                OrdemDirecao = consulta.OrdemDirecao,
            };

            switch (consulta.OrdemNome)
            {
                case "Id":
                    consultaDominio.OrdemNome = "ChecagemId";
                    break;
                case "Rfid":
                    consultaDominio.OrdemNome = "ChecagemRfid";
                    break;
            }

            var resultadoDominio = await ChecagemServico.ListarAsync(consultaDominio);

            var resultado = new PaginadoOrdenado<ChecagemApp>()
            {
                ItensPorPagina = resultadoDominio.ItensPorPagina,
                ContagemDePaginas = resultadoDominio.ContagemDePaginas,
                ContagemDeLinhas = resultadoDominio.ContagemDeLinhas,
                PaginaAtual = resultadoDominio.PaginaAtual,
                OrdemDirecao = resultadoDominio.OrdemDirecao,
                Itens = Mapper.Map<List<ChecagemApp>>(resultadoDominio.Itens)
            };

            switch (resultadoDominio.OrdemNome)
            {
                case "ChecagemId":
                    resultado.OrdemNome = "Id";
                    break;
                case "ChecagemRfid":
                    resultado.OrdemNome = "Rfid";
                    break;
            }

            return resultado;

        }

        public Task<List<ChecagemApp>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ChecagemApp> PegarAsync(long id)
        {
            var resultadoDominio = await ChecagemServico.PegarAsync(id);

            var resultado = Mapper.Map<ChecagemApp>(resultadoDominio);

            return resultado;
        }

        public Task<bool> DeletarAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AlterarAsync(ChecagemApp instancia)
        {
            var instanciaDominio = Mapper.Map<Checagem>(instancia);

            var resultado = await ChecagemServico.AlterarAsync(instanciaDominio);

            return resultado;
        }

        public async Task<long> AdicionarAsync(ChecagemApp instancia)
        {
            var instanciaDominio = Mapper.Map<Checagem>(instancia);

            var resultado = await ChecagemServico.AdicionarAsync(instanciaDominio);

            return resultado;
        }

        public Task<IEnumerable<ValidationResult>> ValidarAsync(ChecagemApp instancia)
        {
            throw new NotImplementedException();
        }
    }
}
