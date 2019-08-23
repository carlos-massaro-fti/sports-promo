using SportsPromo.Comum.Dados;
using SportsPromo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Interfaces.Dados.Repositorios
{
    public interface IMarcoRepositorio
    {
        PaginadoOrdenado<Marco> Listar(PaginadoOrdenado<Marco> consulta);
        List<Marco> Listar();
        Marco Pegar(long id);
        bool Deletar(long id);
        bool Alterar(Marco instancia);
        long Adicionar(Marco instancia);

        Task<PaginadoOrdenado<Esporte>> ListarAsync(PaginadoOrdenado<Esporte> consulta);
        Task <List<Marco>> ListarAsync();
        Task <Marco> PegarAsync(long id);
        Task <bool> DeletarAsync(long id);
        Task <bool> AlterarAsync(Marco instancia);
        Task <long> AdicionarAsync(Marco instancia);

    }
}
