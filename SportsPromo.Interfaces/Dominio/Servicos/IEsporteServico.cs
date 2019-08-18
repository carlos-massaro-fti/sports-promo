using SportsPromo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SportsPromo.Interfaces.Dominio.Servicos
{
    public interface IEsporteServico
    {
        List<Esporte> Listar();
        Esporte Pegar(long id);
        bool Deletar(long id);
        bool Alterar(Esporte instancia);
        long Adicionar(Esporte instancia);
        IEnumerable<ValidationResult> Validar(Esporte instancia);

    }
}
