using SportsPromo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SportsPromo.Comum.Dados;
namespace SportsPromo.Interfaces.Dominio.Servicos
{
    public interface ICategoriaServico
    {
        PaginadoOrdenado<Categoria> Listar(PaginadoOrdenado<Categoria> consulta);
        List<Categoria> Listar();
        Categoria Pegar(long id);
        bool Deletar(long id);
        bool Alterar(Categoria instancia);
        long Adicionar(Categoria instancia);
        IEnumerable<ValidationResult> Validar(Categoria instancia);

        Task<PaginadoOrdenado<Categoria>> ListarAsync(PaginadoOrdenado<Categoria> consulta);
        Task<List<Categoria>> ListarAsync();
        Task<Categoria> PegarAsync(long id);
        Task<bool> DeletarAsync(long id);
        Task<bool> AlterarAsync(Categoria instancia);
        Task<long> AdicionarAsync(Categoria instancia);
        Task<IEnumerable<ValidationResult>> ValidarAsync(Categoria instancia);
    }
}
