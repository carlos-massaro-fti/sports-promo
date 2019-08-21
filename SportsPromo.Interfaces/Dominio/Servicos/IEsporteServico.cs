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
    public interface IEsporteServico
    {
        PaginadoOrdenado<Esporte> Listar(PaginadoOrdenado<Esporte> consulta);
        List<Esporte> Listar();
        Esporte Pegar(long id);
        bool Deletar(long id);
        bool Alterar(Esporte instancia);
        long Adicionar(Esporte instancia);
        IEnumerable<ValidationResult> Validar(Esporte instancia);

        Task<PaginadoOrdenado<Esporte>> ListarAsync(PaginadoOrdenado<Esporte> consulta);
        Task<List<Esporte>> ListarAsync();
        Task<Esporte> PegarAsync(long id);
        Task<bool> DeletarAsync(long id);
        Task<bool> AlterarAsync(Esporte instancia);
        Task<long> AdicionarAsync(Esporte instancia);
        Task<IEnumerable<ValidationResult>> ValidarAsync(Esporte instancia);

    }
}
