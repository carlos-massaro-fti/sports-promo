using AutoMapper;
using SportsPromo.App.Interfaces.Manipuladores;
using SportsPromo.App.Modelos;
using SportsPromo.Comum.Dados;
using SportsPromo.Dominio.Modelos;
using SportsPromo.Interfaces.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.App.Core.Manipuladores
{
    public class EquipeManipulador : IEquipeManipulador
    {
        protected IEquipeServico EquipeServico { get; }
        protected IMapper Mapper { get; }


        public EquipeManipulador(IEquipeServico equipeServico, IMapper mapper)
        {
            EquipeServico = equipeServico;
            Mapper = mapper;
        }
        public long Adicionar(EquipeApp instancia)
        {
            var modelDominio = Mapper.Map<Equipe>(instancia);

            var result = EquipeServico.Adicionar(modelDominio);

            return result;
        }

        public bool Alterar(EquipeApp instancia)
        {
            throw new NotImplementedException();
        }

        public bool Deletar(long id)
        {
            throw new NotImplementedException();
        }

        public List<EquipeApp> Listar()
        {
            throw new NotImplementedException();
        }

        public EquipeApp Pegar(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ValidationResult> Validar(EquipeApp instancia)
        {
            throw new NotImplementedException();
        }



        public PaginadoOrdenado<EquipeApp> Listar(PaginadoOrdenado<EquipeApp> consulta)
        {
            var consultaDominio = new PaginadoOrdenado<Equipe>()
            {
                ItensPorPagina = consulta.ItensPorPagina,
                PaginaAtual = consulta.PaginaAtual,
                OrdemDirecao = consulta.OrdemDirecao,
            };

            switch (consulta.OrdemNome)
            {
                case "Nome":
                    consultaDominio.OrdemNome = "EquipeNome";
                    break;
                case "Id":
                    consultaDominio.OrdemNome = "EquipeId";
                    break;
            }

            var resultadoDominio = EquipeServico.Listar(consultaDominio);

            var resultado = new PaginadoOrdenado<EquipeApp>()
            {
                ItensPorPagina = resultadoDominio.ItensPorPagina,
                ContagemDePaginas = resultadoDominio.ContagemDePaginas,
                ContagemDeLinhas = resultadoDominio.ContagemDeLinhas,
                PaginaAtual = resultadoDominio.PaginaAtual,
                Itens = Mapper.Map<List<EquipeApp>>(resultadoDominio.Itens),
                OrdemDirecao = resultadoDominio.OrdemDirecao
            };

            switch (resultadoDominio.OrdemNome)
            {
                case "EquipeNome":
                    resultado.OrdemNome = "Nome";
                    break;
                case "EquipeId":
                    resultado.OrdemNome = "Id";
                    break;
            }

            return resultado;
        }

        public async Task<PaginadoOrdenado<EquipeApp>> ListarAsync(PaginadoOrdenado<EquipeApp> consulta)
        {

            var consultaDominio = new PaginadoOrdenado<Equipe>()
            {
                ItensPorPagina = consulta.ItensPorPagina,
                PaginaAtual = consulta.PaginaAtual,
                OrdemDirecao = consulta.OrdemDirecao,
            };

            switch (consulta.OrdemNome)
            {
                case "Id":
                    consultaDominio.OrdemNome = "EquipeId";
                    break;
                case "Nome":
                    consultaDominio.OrdemNome = "EquipeNome";
                    break;
            }

            var resultadoDominio = await EquipeServico.ListarAsync(consultaDominio);

            var resultado = new PaginadoOrdenado<EquipeApp>()
            {
                ItensPorPagina = resultadoDominio.ItensPorPagina,
                ContagemDePaginas = resultadoDominio.ContagemDePaginas,
                ContagemDeLinhas = resultadoDominio.ContagemDeLinhas,
                PaginaAtual = resultadoDominio.PaginaAtual,
                OrdemDirecao = resultadoDominio.OrdemDirecao,
                Itens = Mapper.Map<List<EquipeApp>>(resultadoDominio.Itens)
            };

            switch (resultadoDominio.OrdemNome)
            {
                case "EquipeId":
                    resultado.OrdemNome = "Id";
                    break;
                case "EquipeNome":
                    resultado.OrdemNome = "Nome";
                    break;
            }

            return resultado;

        }

        public Task<List<EquipeApp>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<EquipeApp> PegarAsync(long id)
        {
            var resultadoDominio = await EquipeServico.PegarAsync(id);

            var resultado = Mapper.Map<EquipeApp>(resultadoDominio);

            return resultado;
        }

        public Task<bool> DeletarAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AlterarAsync(EquipeApp instancia)
        {
            var instanciaDominio = Mapper.Map<Equipe>(instancia);

            var resultado = await EquipeServico.AlterarAsync(instanciaDominio);

            return resultado;
        }

        public async Task<long> AdicionarAsync(EquipeApp instancia)
        {
            var instanciaDominio = Mapper.Map<Equipe>(instancia);

            var resultado = await EquipeServico.AdicionarAsync(instanciaDominio);

            return resultado;
        }

        public Task<IEnumerable<ValidationResult>> ValidarAsync(EquipeApp instancia)
        {
            throw new NotImplementedException();
        }
    }
}
