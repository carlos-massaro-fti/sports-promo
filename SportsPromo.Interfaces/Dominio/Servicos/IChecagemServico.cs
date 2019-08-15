using SportsPromo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SportsPromo.Interfaces.Dominio.Servicos
{
    interface IChecagemServico
    {
        List<Checagem> Listar();
        Checagem Pegar(long id);
        bool Deletar(long id);
        bool Alterar(Checagem instancia);
        long Adicionar(Checagem instancia);
        IEnumerable<ValidationResult> Validate(Checagem instancia);
    }
}
