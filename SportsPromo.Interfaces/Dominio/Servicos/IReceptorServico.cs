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
        IReceptorRepositorio ReceptorRepositorio { get; }
        List<Receptor> Listar();
        Receptor Pegar(long id);
        bool Deletar(long id);
        bool Alterar(Receptor instancia);
        long Adicionar(Receptor instancia);
        IEnumerable<ValidationResult> Validar(Receptor instancia);
    }
}
