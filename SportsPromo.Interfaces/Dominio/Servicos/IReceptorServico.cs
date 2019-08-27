using SportsPromo.Comum.Dados;
using SportsPromo.Dominio.Modelos;
using SportsPromo.Interfaces.Dados.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Interfaces.Dominio.Servicos
{
    public interface IReceptorServico
    {
        PaginadoOrdenado<Receptor> Listar(PaginadoOrdenado<Receptor> consulta);
        List<Receptor> Listar();
        Receptor Pegar(long id);
        bool Deletar(long id);
        bool Alterar(Receptor instancia);
        long Adicionar(Receptor instancia);
        IEnumerable<ValidationResult> Validar(Receptor instancia);

        Task<PaginadoOrdenado<Receptor>> ListarAsync(PaginadoOrdenado<Receptor> consulta);
        Task<List<Receptor>> ListarAsync();
        Task<Receptor> PegarAsync(long id);
        Task<bool> DeletarAsync(long id);
        Task<bool> AlterarAsync(Receptor instancia);
        Task<long> AdicionarAsync(Receptor instancia);
        Task<IEnumerable<ValidationResult>> ValidarAsync(Receptor instancia);
    }
}
