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
    public class ChecagemServico : IChecagemServico
    {
        public IChecagemRepositorio ChecagemRepositorio { get; }
        public ChecagemServico(IChecagemRepositorio checagemRepositorio)
        {
            ChecagemRepositorio = checagemRepositorio;
        }
        public long Adicionar(Checagem instancia)
        {
            var validationResult = Validar(instancia);

            if (validationResult.Any())
            {
                throw new AppException(validationResult.First().ErrorMessage, validationResult);
            }

            var result = ChecagemRepositorio.Adicionar(instancia);

            return result;
        }

        public async Task<long> AdicionarAsync(Checagem instancia)
        {
            var resultado = await ChecagemRepositorio.AdicionarAsync(instancia);

            return resultado;
        }

        public bool Alterar(Checagem instancia)
        {
            var atualInstancia = ChecagemRepositorio.Pegar(instancia.ChecagemId);

            Mesclar(atualInstancia, instancia);

            var validationResult = Validar(atualInstancia);

            if (validationResult.Any())
            {
                throw new AppException(validationResult.First().ErrorMessage, validationResult);
            }

            var result = ChecagemRepositorio.Alterar(atualInstancia);

            return result;
        }

        private void Mesclar(Checagem atualInstancia, Checagem novaInstancia)
        {
            atualInstancia.ChecagemRfid = novaInstancia.ChecagemRfid;
            atualInstancia.ChecagemEm = novaInstancia.ChecagemEm;
        }

        public async Task<bool> AlterarAsync(Checagem instancia)
        {
            var atualInstancia = await ChecagemRepositorio.PegarAsync(instancia.ChecagemId);

            Mesclar(atualInstancia, instancia);

            var validationResult = Validar(atualInstancia);

            if (validationResult.Any())
            {
                throw new AppException(validationResult.First().ErrorMessage, validationResult);
            }

            var result = await ChecagemRepositorio.AlterarAsync(atualInstancia);

            return result;
        }

        public bool Deletar(long id)
        {
            var result = ChecagemRepositorio.Deletar(id);

            return result;
        }

        public Task<bool> DeletarAsync(long id)
        {
            throw new NotImplementedException();
        }

        public PaginadoOrdenado<Checagem> Listar(PaginadoOrdenado<Checagem> consulta)
        {
            var result = ChecagemRepositorio.Listar(consulta);

            return result;
        }

        public List<Checagem> Listar()
        {
            var result = ChecagemRepositorio.Listar();

            return result;
        }

        public async Task<PaginadoOrdenado<Checagem>> ListarAsync(PaginadoOrdenado<Checagem> consulta)
        {
            var resultado = await ChecagemRepositorio.ListarAsync(consulta);

            return resultado;
        }

        public Task<List<Checagem>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public Checagem Pegar(long id)
        {
            var result = ChecagemRepositorio.Pegar(id);

            return result;
        }

        public async Task<Checagem> PegarAsync(long id)
        {
            var result = await ChecagemRepositorio.PegarAsync(id);

            return result;
        }

        public IEnumerable<ValidationResult> Validar(Checagem instancia)
        {
            if (DateTime.Now - instancia.ChecagemEm > TimeSpan.FromHours(1))
            {
                yield return new ValidationResult("Hora inválida", new string[] { "ChecagemEm" });
            }

            if (string.IsNullOrWhiteSpace(instancia.ChecagemRfid))
            {
                yield return new ValidationResult("Rfid inválido", new string[] { "ChecagemRfid" });
            }

            if (!(instancia.ChecagemReceptorId > 0))
            {
                yield return new ValidationResult("Informe o Receptor", new string[] { "ChecagemReceptorId" });
            }
        }

        public Task<IEnumerable<ValidationResult>> ValidarAsync(Checagem instancia)
        {
            throw new NotImplementedException();
        }
    }
}
