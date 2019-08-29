using SportsPromo.Comum.Dados;
using SportsPromo.Comum.Exceptions;
using SportsPromo.Dominio.Modelos;
using SportsPromo.Interfaces.Dados.Repositorios;
using SportsPromo.Interfaces.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Dominio.Servicos
{
    public class EsporteServico : IEsporteServico
    {
        public IEsporteRepositorio EsporteRepositorio { get; }

        public EsporteServico(IEsporteRepositorio esporteRepositorio)
        {
            EsporteRepositorio = esporteRepositorio;
        }

        public long Adicionar(Esporte instancia)
        {
            var validationResult = Validar(instancia);

            if (validationResult.Any())
            {
                throw new AppException(validationResult.First().ErrorMessage, validationResult);
            }

            var result = EsporteRepositorio.Adicionar(instancia);

            return result;
        }

        public bool Alterar(Esporte instancia)
        {
            var atualInstancia = EsporteRepositorio.Pegar(instancia.EsporteId);

            Mesclar(atualInstancia, instancia);

            var validationResult = Validar(atualInstancia);

            if (validationResult.Any())
            {
                throw new AppException(validationResult.First().ErrorMessage, validationResult);
            }

            var result = EsporteRepositorio.Alterar(atualInstancia);

            return result;
        }

        private void Mesclar(Esporte atualInstancia, Esporte novaInstancia)
        {
            atualInstancia.EsporteNome = novaInstancia.EsporteNome;
        }

        public bool Deletar(long id)
        {
            var result = EsporteRepositorio.Deletar(id);

            return result;
        }

        public List<Esporte> Listar()
        {
            var result = EsporteRepositorio.Listar();

            return result;
        }

        public Esporte Pegar(long id)
        {
            var result = EsporteRepositorio.Pegar(id);

            return result;
        }

        public IEnumerable<ValidationResult> Validar(Esporte instancia)
        {
            if (instancia.EsporteNome.Length > 256)
            {
                yield return new ValidationResult("O nome do esporte não pode ter mais de 256 caracteres", new string[] { "EsporteNome" });
            }
            if (instancia.EsporteNome.Length < 3)
            {
                yield return new ValidationResult("O nome do esporte não pode ter menos de 3 caracteres", new string[] { "EsporteNome" });
            }
        }

        public PaginadoOrdenado<Esporte> Listar(PaginadoOrdenado<Esporte> consulta)
        {
            var result = EsporteRepositorio.Listar(consulta);

            return result;
        }

        public async Task<PaginadoOrdenado<Esporte>> ListarAsync(PaginadoOrdenado<Esporte> consulta)
        {
            var resultado = await EsporteRepositorio.ListarAsync(consulta);

            return resultado;
        }

        public Task<List<Esporte>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Esporte> PegarAsync(long id)
        {
            var resultado = await EsporteRepositorio.PegarAsync(id);

            return resultado;
        }

        public Task<bool> DeletarAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AlterarAsync(Esporte instancia)
        {
            var atualInstancia = await EsporteRepositorio.PegarAsync(instancia.EsporteId);

            Mesclar(atualInstancia, instancia);

            var validationResult = Validar(atualInstancia);

            if (validationResult.Any())
            {
                throw new AppException(validationResult.First().ErrorMessage, validationResult);
            }

            var result = await EsporteRepositorio.AlterarAsync(atualInstancia);

            return result;
        }

        public async Task<long> AdicionarAsync(Esporte instancia)
        {
            var resultado = await EsporteRepositorio.AdicionarAsync(instancia);

            return resultado;
        }

        public async Task<IEnumerable<ValidationResult>> ValidarAsync(Esporte instancia)
        {
            throw new NotImplementedException();
        }
    }
}

