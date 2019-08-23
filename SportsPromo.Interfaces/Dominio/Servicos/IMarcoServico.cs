using SportsPromo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsPromo.Interfaces.Dados.Repositorios;
using SportsPromo.Comum.Dados;

namespace SportsPromo.Interfaces.Dominio.Servicos
{
    public interface IMarcoServico
    {
        PaginadoOrdenado<Marco> Listar(PaginadoOrdenado<Marco> consulta);
        List<Marco> Listar();
        Marco Pegar(long id);
        bool Deletar(long id);
        bool Alterar(Marco instancia);
        long Adicionar(Marco instancia);
        IEnumerable<ValidationResult> Validar(Marco instancia);

        Task<PaginadoOrdenado<Marco>> ListarAsync(PaginadoOrdenado<Marco> consulta);
        Task<List<Marco>> ListarAsync();
        Task<Marco> PegarAsync(long id);
        Task<bool> DeletarAsync(long id);
        Task<bool> AlterarAsync(Marco instancia);
        Task<long> AdicionarAsync(Marco instancia);
        Task<IEnumerable<ValidationResult>> ValidarAsync(Marco instancia);


    }
}
