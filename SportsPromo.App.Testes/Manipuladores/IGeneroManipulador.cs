using SportsPromo.App.Core.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.App.Interfaces.Manipuladores
{
    public interface IGeneroManipulador
    {
        List<GeneroApp> Listar();
        GeneroApp Pegar(long id);
        bool Deletar(long id);
        bool Alterar(GeneroApp instancia);
        long Adicionar(GeneroApp instancia);
        IEnumerable<ValidationResult> Validar(GeneroApp instancia);
    }
}
