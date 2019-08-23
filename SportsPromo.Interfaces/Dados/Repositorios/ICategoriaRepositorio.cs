using SportsPromo.Comum.Dados;
using SportsPromo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Interfaces.Dados.Repositorios
{
    public interface ICategoriaRepositorio
    {
        PaginadoOrdenado<Categoria> Listar(PaginadoOrdenado<Categoria> consulta);
        List<Categoria> Listar();
        Categoria Pegar(long id);
        bool Deletar(long id);
        bool Alterar(Categoria instancia);
        long Adicionar(Categoria instancia);

        Task<PaginadoOrdenado<Categoria>> ListarAsync(PaginadoOrdenado<Categoria> consulta);
        Task<List<Categoria>> ListarAsync();
        Task<Categoria> PegarAsync(long id);
        Task<bool> DeletarAsync(long id);
        Task<bool> AlterarAsync(Categoria instancia);
        Task<long> AdicionarAsync(Categoria instancia);
    }
}
