using SportsPromo.Comum.Dados;
using SportsPromo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Interfaces.Dados.Repositorios
{
    public interface IEventoRepositorio
    {
        PaginadoOrdenado<Evento> Listar(PaginadoOrdenado<Evento> consulta);
        List<Evento> Listar();
        Evento Pegar(long id);
        bool Deletar(long id);
        bool Alterar(Evento instancia);
        long Adicionar(Evento instancia);

        Task<PaginadoOrdenado<Evento>> ListarAsync(PaginadoOrdenado<Evento> consulta);
        Task<List<Evento>> ListarAsync();
        Task<Evento> PegarAsync(long id);
        Task<bool> DeletarAsync(long id);
        Task<bool> AlterarAsync(Evento instancia);
        Task<long> AdicionarAsync(Evento instancia);

    }
}
