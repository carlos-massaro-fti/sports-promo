using SportsPromo.Comum.Dados;
using SportsPromo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Interfaces.Dados.Repositorios
{
    public interface IEsporteRepositorio
    {
        PaginadoOrdenado<Esporte> Listar(PaginadoOrdenado<Esporte> consulta);
        List<Esporte> Listar();
        Esporte Pegar(long id);
        bool Deletar(long id);
        bool Alterar(Esporte instancia);
        long Adicionar(Esporte instancia);

        Task<PaginadoOrdenado<Esporte>> ListarAsync(PaginadoOrdenado<Esporte> consulta);
        Task<List<Esporte>> ListarAsync();
        Task<Esporte> PegarAsync(long id);
        Task<bool> DeletarAsync(long id);
        Task<bool> AlterarAsync(Esporte instancia);
        Task<long> AdicionarAsync(Esporte instancia);

    }
}
