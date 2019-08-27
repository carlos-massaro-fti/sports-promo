using SportsPromo.App.Core.Modelos;
using SportsPromo.Comum.Dados;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SportsPromo.App.Interfaces.Manipuladores
{
    public interface ICategoriaManipulador
    {
        PaginadoOrdenado<CategoriaApp> Listar(PaginadoOrdenado<CategoriaApp> consulta);
        List<CategoriaApp> Listar();
        CategoriaApp Pegar(long id);
        bool Deletar(long id);
        bool Alterar(CategoriaApp instancia);
        long Adicionar(CategoriaApp instancia);
        IEnumerable<ValidationResult> Validar(CategoriaApp instancia);


        Task<PaginadoOrdenado<CategoriaApp>> ListarAsync(PaginadoOrdenado<CategoriaApp> consulta);
        Task<List<CategoriaApp>> ListarAsync();
        Task<CategoriaApp> PegarAsync(long id);
        Task<bool> DeletarAsync(long id);
        Task<bool> AlterarAsync(CategoriaApp instancia);
        Task<long> AdicionarAsync(CategoriaApp instancia);
        Task<IEnumerable<ValidationResult>> ValidarAsync(CategoriaApp instancia);

    }
}
