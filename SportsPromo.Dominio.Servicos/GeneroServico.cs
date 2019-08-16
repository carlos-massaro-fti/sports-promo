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
    public class GeneroServico : IGeneroServico
    {
        public IGeneroRepositorio GeneroRepositorio { get; }

        public GeneroServico(IGeneroRepositorio generoRepositorio)
        {
            GeneroRepositorio = generoRepositorio;
        }
        public long Adicionar(Genero instancia)
        {
            var validationResult = Validar(instancia);

            if (validationResult.Any())
            {
                throw new AppException(validationResult.First().ErrorMessage, validationResult);
            }

            var result = GeneroRepositorio.Adicionar(instancia);

            return result;
        }

        public bool Alterar(Genero instancia)
        {
            var atualInstancia = GeneroRepositorio.Pegar(instancia.GeneroId);

            Mesclar(atualInstancia, instancia);

            var validationResult = Validar(atualInstancia);

            if (validationResult.Any())
            {
                throw new AppException(validationResult.First().ErrorMessage, validationResult);
            }

            var result = GeneroRepositorio.Alterar(atualInstancia);

            return result;
        }

        private void Mesclar(Genero atualInstancia, Genero novaInstancia)
        {
            atualInstancia.GeneroNome = novaInstancia.GeneroNome;
        }

        public bool Deletar(long id)
        {
            var result = GeneroRepositorio.Deletar(id);

            return result;
        }

        public List<Genero> Listar()
        {
            var result = GeneroRepositorio.Listar();

            return result;
        }

        public Genero Pegar(long id)
        {
            var result = GeneroRepositorio.Pegar(id);

            return result;
        }

        public IEnumerable<ValidationResult> Validar(Genero instancia)
        {
            if (instancia.GeneroNome.Length > 256)
            {
                yield return new ValidationResult("O nome não pode ter mais de 256 caracteres", new string[] { "GeneroNome" });
            }
            if (instancia.GeneroNome.Length < 3)
            {
                yield return new ValidationResult("O Nome não pode ter menos de 3 caracteres", new string[] { "GeneronNome" });
            }
        }
    }
}
