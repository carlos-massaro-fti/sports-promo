using SportsPromo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Interfaces.Dominio.Servicos
{
   public interface IReceptor
    {
        Receptor Pegar(long id);
        bool Deletar(long id);
        bool Alterar(Receptor instancia);
        long Adicionar(Receptor instancia);
    }
}
