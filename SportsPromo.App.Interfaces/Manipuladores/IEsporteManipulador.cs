using SportsPromo.App.Core.Modelos;
using SportsPromo.Comum.Dados;
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
        PaginadoOrdenado<EsporteApp> Listar(PaginadoOrdenado<EsporteApp> consulta);
        List<EsporteApp> Listar();
        EsporteApp Pegar(long id);
        bool Deletar(long id);
        bool Alterar(EsporteApp instancia);
        long Adicionar(EsporteApp instancia);
        IEnumerable<ValidationResult> Validar(EsporteApp instancia);
    }
}
