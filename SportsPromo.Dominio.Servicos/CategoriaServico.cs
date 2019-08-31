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
using SportsPromo.Comum.Dados;

namespace SportsPromo.Dominio.Servicos
{
    public class CategoriaServico : ICategoriaServico
    {
        public ICategoriaRepositorio CategoriaRepositorio { get; }
        public CategoriaServico(ICategoriaRepositorio categoriaRepositorio)
        {
            CategoriaRepositorio = categoriaRepositorio;
        }

        public long Adicionar(Categoria instancia)
        {
            var validationResult = Validar(instancia);

            if (validationResult.Any())
            {
                throw new AppException(validationResult.First().ErrorMessage, validationResult);
            }

            var result = CategoriaRepositorio.Adicionar(instancia);

            return result;
        }

        public bool Alterar(Categoria instancia)
        {
            var atualInstancia = CategoriaRepositorio.Pegar(instancia.CategoriaId);

            Mesclar(atualInstancia, instancia);

            var validationResult = Validar(atualInstancia);

            if (validationResult.Any())
            {
                throw new AppException(validationResult.First().ErrorMessage, validationResult);
            }

            var result = CategoriaRepositorio.Alterar(atualInstancia);

            return result;
        }
        private void Mesclar(Categoria atualInstancia, Categoria novaInstancia)
        {
            atualInstancia.CategoriaNome = novaInstancia.CategoriaNome;
        }


        public bool Deletar(long id)
        {
            var result = CategoriaRepositorio.Deletar(id);

            return result;
        }

        public PaginadoOrdenado<Categoria> Listar(PaginadoOrdenado<Categoria> consulta)
        {
            var result = CategoriaRepositorio.Listar(consulta);

            return result;
        }
        public List<Categoria> Listar()
        {
            var result = CategoriaRepositorio.Listar();

            return result;
        }

        public Categoria Pegar(long id)
        {
            var result = CategoriaRepositorio.Pegar(id);

            return result;
        }

        public IEnumerable<ValidationResult> Validar(Categoria instancia)
        {
            if (instancia.CategoriaNome.Length > 256)
            {
                yield return new ValidationResult("O Nome não pode ter mais de 256 caracteres", new string[] { "CategoriaNome" });
            }
            if (instancia.CategoriaNome.Length < 3)
            {
                yield return new ValidationResult("O Nome não pode ter menos de 3 caracteres", new string[] { "CategoriaNome" });
            }

            if (instancia.CategoriaIdadeMin > instancia.CategoriaIdadeMax)
            {
                yield return new ValidationResult("A idade minima não pode ser menor que a idade maxima", new string[] { "CategoriaIdadeMin", "CategoriaIdadeMax" });
            }

            if (!(instancia.CategoriaGeneroId > 0))
            {
                yield return new ValidationResult("Favor selecionar um genero", new string[] { "CategoriaGeneroId" });
            }
        }

        public Task<IEnumerable<ValidationResult>> ValidarAsync(Categoria instancia)
        {
            throw new NotImplementedException();
        }
        public async Task<long> AdicionarAsync(Categoria instancia)
        {
            var resultado = await CategoriaRepositorio.AdicionarAsync(instancia);

            return resultado;
        }
        public Task<bool> AlterarAsync(Categoria instancia)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeletarAsync(long id)
        {
            throw new NotImplementedException();
        }
        public async Task<PaginadoOrdenado<Categoria>> ListarAsync(PaginadoOrdenado<Categoria> consulta)
        {
            var resultado = await CategoriaRepositorio.ListarAsync(consulta);

            return resultado;
        }
        public Task<List<Categoria>> ListarAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<Categoria> PegarAsync(long id)
        {
            var result = await CategoriaRepositorio.PegarAsync(id);

            return result;
        }
    }
}
