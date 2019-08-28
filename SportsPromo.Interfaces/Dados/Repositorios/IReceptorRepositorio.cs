using SportsPromo.Comum.Dados;
using SportsPromo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Interfaces.Dados.Repositorios
{
    public interface IReceptorRepositorio
    {
        PaginadoOrdenado<Receptor> Listar(PaginadoOrdenado<Receptor> consulta);
        List<Receptor> Listar();
        Receptor Pegar(long id);
        bool Deletar(long id);
        bool Alterar(Receptor instancia);
        long Adicionar(Receptor instancia);

        Task<PaginadoOrdenado<Receptor>> ListarAsync(PaginadoOrdenado<Receptor> consulta);
        Task<List<Receptor>> ListarAsync();
        Task<Receptor> PegarAsync(long id);
        Task<bool> DeletarAsync(long id);
        Task<bool> AlterarAsync(Receptor instancia);
        Task<long> AdicionarAsync(Receptor instancia);
    }
}
