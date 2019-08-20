using SportsPromo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Interfaces.Dominio.Servicos
{
    interface IMarcoServico
    {
        //IMarcoServico MarcoRepositorio { get; }
        List<Marco> Listar();
        Marco Pegar(long id);
        bool Deletar(long id);
        bool Alterar(Marco instancia);
        long Adicionar(Marco instancia);
        IEnumerable<ValidationResult> Validar(Marco instancia);
    }
}
