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
    public interface IChecagemServico
    {
        PaginadoOrdenado<Checagem> Listar(PaginadoOrdenado<Checagem> consulta);
        List<Checagem> Listar();
        Checagem Pegar(long id);
        bool Deletar(long id);
        bool Alterar(Checagem instancia);
        long Adicionar(Checagem instancia);
        IEnumerable<ValidationResult> Validar(Checagem instancia);

        Task<PaginadoOrdenado<Checagem>> ListarAsync(PaginadoOrdenado<Checagem> consulta);
        Task<List<Checagem>> ListarAsync();
        Task<Checagem> PegarAsync(long id);
        Task<bool> DeletarAsync(long id);
        Task<bool> AlterarAsync(Checagem instancia);
        Task<long> AdicionarAsync(Checagem instancia);
        Task<IEnumerable<ValidationResult>> ValidarAsync(Checagem instancia);

    }
}
