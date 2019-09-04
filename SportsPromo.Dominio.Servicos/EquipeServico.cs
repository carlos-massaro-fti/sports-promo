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
    public class EquipeServico : IEquipeServico
    {
        public IEquipeRepositorio EquipeRepositorio { get; }
        public EquipeServico(IEquipeRepositorio equipeRepositorio)
        {
            EquipeRepositorio = equipeRepositorio;
        }
        public long Adicionar(Equipe instancia)
        {
            var validationResult = Validar(instancia);

            if (validationResult.Any())
            {
                throw new AppException(validationResult.First().ErrorMessage, validationResult);
            }

            var result = EquipeRepositorio.Adicionar(instancia);

            return result;
        }

        public async Task<long> AdicionarAsync(Equipe instancia)
        {
            var validationResult = await ValidarAsync(instancia);

            if (validationResult.Any())
            {
                throw new AppException(validationResult.First().ErrorMessage, validationResult);
            }

            var resultado = await EquipeRepositorio.AdicionarAsync(instancia);

            return resultado;
        }

        public bool Alterar(Equipe instancia)
        {
            var atualInstancia = EquipeRepositorio.Pegar(instancia.EquipeId);

            Mesclar(atualInstancia, instancia);

            var validationResult = Validar(atualInstancia);

            if (validationResult.Any())
            {
                throw new AppException(validationResult.First().ErrorMessage, validationResult);
            }

            var result = EquipeRepositorio.Alterar(atualInstancia);

            return result;
        }

        private void Mesclar(Equipe atualInstancia, Equipe novaInstancia)
        {
            atualInstancia.EquipeNome = novaInstancia.EquipeNome;
            atualInstancia.EquipeProvaId = novaInstancia.EquipeProvaId;
        }

        public async Task<bool> AlterarAsync(Equipe instancia)
        {
            var atualInstancia = await EquipeRepositorio.PegarAsync(instancia.EquipeId);

            Mesclar(atualInstancia, instancia);

            var validationResult = await ValidarAsync(atualInstancia);

            if (validationResult.Any())
            {
                throw new AppException(validationResult.First().ErrorMessage, validationResult);
            }

            var result = await EquipeRepositorio.AlterarAsync(atualInstancia);

            return result;
        }

        public bool Deletar(long id)
        {
            var result = EquipeRepositorio.Deletar(id);

            return result;
        }

        public Task<bool> DeletarAsync(long id)
        {
            throw new NotImplementedException();
        }

        public PaginadoOrdenado<Equipe> Listar(PaginadoOrdenado<Equipe> consulta)
        {
            var result = EquipeRepositorio.Listar(consulta);

            return result;
        }

        public List<Equipe> Listar()
        {
            var result = EquipeRepositorio.Listar();

            return result;
        }

        public async Task<PaginadoOrdenado<Equipe>> ListarAsync(PaginadoOrdenado<Equipe> consulta)
        {
            var resultado = await EquipeRepositorio.ListarAsync(consulta);

            return resultado;
        }

        public Task<List<Equipe>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public Equipe Pegar(long id)
        {
            var result = EquipeRepositorio.Pegar(id);

            return result;
        }

        public async Task<Equipe> PegarAsync(long id)
        {
            var result = await EquipeRepositorio.PegarAsync(id);

            return result;
        }

        public IEnumerable<ValidationResult> Validar(Equipe instancia)
        {
            if (instancia.EquipeNome.Length < 4)
            {
                yield return new ValidationResult("Tamanho do nome inválido", new string[] { "EquipeNome" });
            }

            if (instancia.EquipeProvaId > 0)
            {
                yield return new ValidationResult("Informe a prova", new string[] { "EquipeProvaId" });
            }

            if (!(instancia.EquipeId > 0))
            {
                yield return new ValidationResult("Informe a Equipe", new string[] { "EquipeId" });
            }
        }

        public async Task<IEnumerable<ValidationResult>> ValidarAsync(Equipe instancia)
        {
            await Task.Yield();

            return Validar(instancia);
        }
    }
}
