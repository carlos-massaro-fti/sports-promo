using SportsPromo.Interfaces.Dados.Repositorios;
using SportsPromo.Interfaces.Dominio.Servicos;
using SportsPromo.Dominio.Modelos;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsPromo.Comum.Exceptions;

namespace SportsPromo.Dominio.Servicos
{
    public class ReceptorServico : IReceptorServico
    {
        public IReceptorRepositorio ReceptorRepositorio { get; }

        public ReceptorServico(IReceptorRepositorio receptorRepositorio)
        {
            ReceptorRepositorio = receptorRepositorio;
        }

        public long Adicionar(Receptor instancia)
        {
            var validationResult = Validar(instancia);

            if (validationResult.Any())
            {
                throw new AppException(validationResult.First().ErrorMessage, validationResult);
            }

            var result = ReceptorRepositorio.Adicionar(instancia);

            return result;
        }

        public bool Alterar(Receptor instancia)
        {
            var atualInstancia = ReceptorRepositorio.Pegar(instancia.ReceptorId);

            Mesclar(atualInstancia, instancia);

            var validationResult = Validar(atualInstancia);

            if (validationResult.Any())
            {
                throw new AppException(validationResult.First().ErrorMessage, validationResult);
            }

            var result = ReceptorRepositorio.Alterar(atualInstancia);

            return result;
        }

        private void Mesclar(Receptor atualInstancia, Receptor novaInstancia)
        {
            atualInstancia.ReceptorCodigo = novaInstancia.ReceptorCodigo;
        }

        public bool Deletar(long id)
        {
            var result = ReceptorRepositorio.Deletar(id);

            return result;
        }

        public List<Receptor> Listar()
        {
            var result = ReceptorRepositorio.Listar();

            return result;
        }

        public Receptor Pegar(long id)
        {
            var result = ReceptorRepositorio.Pegar(id);

            return result;
        }

        public IEnumerable<ValidationResult> Validar(Receptor instancia)
        {
            if (instancia.ReceptorCodigo.Length > 256)
            {
                yield return new ValidationResult("O código não pode ter mais de 256 caracteres", new string[] { "ReceptorCodigo" });
            }
            if (instancia.ReceptorCodigo.Length < 3)
            {
                yield return new ValidationResult("O código não pode ter menos de 3 caracteres", new string[] { "ReceptorCodigo" });
            }
        }
    }
}
