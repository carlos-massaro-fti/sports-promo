using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsPromo.Dominio.Modelos;
using SportsPromo.Interfaces.Dados.Contextos;
using SportsPromo.Interfaces.Dados.Repositorios;

namespace SportsPromo.Dados.Repositorios
{
    public class ReceptorRepositorio : BaseRepositorio<Receptor>, IReceptorRepositorio
    {
        public ReceptorRepositorio(ISportsPromoContexto contexto) : base(contexto)
        {
        }

        public override long Adicionar(Receptor instancia)
        {
            Contexto.Receptores.Add(instancia);

            Contexto.SaveChanges();

            return instancia.ReceptorId;
        }
    }
}
