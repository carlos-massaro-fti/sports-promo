using SportsPromo.App.Core.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.App.Interfaces.Manipuladores
{
    public interface IEsporteManipulador

    {
        List<EsporteApp> Listar();
        EsporteApp Pegar(long id);
        bool Deletar(long id);
        bool Alterar(EsporteApp instancia);
        long Adicionar(EsporteApp instancia);
        IEnumerable<ValidationResult> Validar(EsporteApp instancia);
    }
}
