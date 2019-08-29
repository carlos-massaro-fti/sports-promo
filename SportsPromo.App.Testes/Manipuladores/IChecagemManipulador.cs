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
    public interface IChecagemManipulador
    {
        PaginadoOrdenado<ChecagemApp> Listar(PaginadoOrdenado<ChecagemApp> consulta);
        List<ChecagemApp> Listar();
        ChecagemApp Pegar(long id);
        bool Deletar(long id);
        bool Alterar(ChecagemApp instancia);
        long Adicionar(ChecagemApp instancia);
        IEnumerable<ValidationResult> Validar(ChecagemApp instancia);


        Task<PaginadoOrdenado<ChecagemApp>> ListarAsync(PaginadoOrdenado<ChecagemApp> consulta);
        Task<List<ChecagemApp>> ListarAsync();
        Task<ChecagemApp> PegarAsync(long id);
        Task<bool> DeletarAsync(long id);
        Task<bool> AlterarAsync(ChecagemApp instancia);
        Task<long> AdicionarAsync(ChecagemApp instancia);
        Task<IEnumerable<ValidationResult>> ValidarAsync(ChecagemApp instancia);
    }
}
