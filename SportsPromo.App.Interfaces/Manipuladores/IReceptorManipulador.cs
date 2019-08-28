using SportsPromo.App.Core.Modelos;
using SportsPromo.App.Modelos;
using SportsPromo.Comum.Dados;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.App.Interfaces.Manipuladores
{
    public interface IReceptorManipulador
    {
        PaginadoOrdenado<ReceptorApp> Listar(PaginadoOrdenado<ReceptorApp> consulta);
        List<ReceptorApp> Listar();
        ReceptorApp Pegar(long id);
        bool Deletar(long id);
        bool Alterar(ReceptorApp instancia);
        long Adicionar(ReceptorApp instancia);
        IEnumerable<ValidationResult> Validar(ReceptorApp instancia);


        Task<PaginadoOrdenado<ReceptorApp>> ListarAsync(PaginadoOrdenado<ReceptorApp> consulta);
        Task<List<ReceptorApp>> ListarAsync();
        Task<ReceptorApp> PegarAsync(long id);
        Task<bool> DeletarAsync(long id);
        Task<bool> AlterarAsync(ReceptorApp instancia);
        Task<long> AdicionarAsync(ReceptorApp instancia);
        Task<IEnumerable<ValidationResult>> ValidarAsync(ReceptorApp instancia);
    }
}
