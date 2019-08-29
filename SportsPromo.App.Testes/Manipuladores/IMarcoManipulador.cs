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
    public interface IMarcoManipulador
    {
        PaginadoOrdenado<MarcoApp> Listar(PaginadoOrdenado<MarcoApp> consulta);
        List<MarcoApp> Listar();
        MarcoApp Pegar(long id);
        bool Deletar(long id);
        bool Alterar(MarcoApp instancia);
        long Adicionar(MarcoApp instancia);
        IEnumerable<ValidationResult> Validar(MarcoApp instancia);

        Task<PaginadoOrdenado<MarcoApp>> ListarAsync(PaginadoOrdenado<MarcoApp> consulta);
        Task<List<MarcoApp>> ListarAsync();
        Task<MarcoApp> PegarAsync(long id);
        Task<bool> DeletarAsync(long id);
        Task<bool> AlterarAsync(MarcoApp instancia);
        Task<long> AdicionarAsync(MarcoApp instancia);
        Task<IEnumerable<ValidationResult>> ValidationResults(MarcoApp instancia);

    }
}
