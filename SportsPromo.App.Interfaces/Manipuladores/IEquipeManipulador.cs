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
    public interface IEquipeManipulador
    {
        PaginadoOrdenado<EquipeApp> Listar(PaginadoOrdenado<EquipeApp> consulta);
        List<EquipeApp> Listar();
        EquipeApp Pegar(long id);
        bool Deletar(long id);
        bool Alterar(EquipeApp instancia);
        long Adicionar(EquipeApp instancia);
        IEnumerable<ValidationResult> Validar(EquipeApp instancia);


        Task<PaginadoOrdenado<EquipeApp>> ListarAsync(PaginadoOrdenado<EquipeApp> consulta);
        Task<List<EquipeApp>> ListarAsync();
        Task<EquipeApp> PegarAsync(long id);
        Task<bool> DeletarAsync(long id);
        Task<bool> AlterarAsync(EquipeApp instancia);
        Task<long> AdicionarAsync(EquipeApp instancia);
        Task<IEnumerable<ValidationResult>> ValidarAsync(EquipeApp instancia);
    }
}
