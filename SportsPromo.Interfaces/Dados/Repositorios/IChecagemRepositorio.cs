using SportsPromo.Comum.Dados;
using SportsPromo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Interfaces.Dados.Repositorios
{
    public interface IChecagemRepositorio
    {
        PaginadoOrdenado<Checagem> Listar(PaginadoOrdenado<Checagem> consulta);
        List<Checagem> Listar();
        Checagem Pegar(long id);
        bool Deletar(long id);
        bool Alterar(Checagem instancia);
        long Adicionar(Checagem instancia);

        Task<PaginadoOrdenado<Checagem>> ListarAsync(PaginadoOrdenado<Checagem> consulta);
        Task<List<Checagem>> ListarAsync();
        Task<Checagem> PegarAsync(long id);
        Task<bool> DeletarAsync(long id);
        Task<bool> AlterarAsync(Checagem instancia);
        Task<long> AdicionarAsync(Checagem instancia);
    }
}
