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
   public class EsporteRepositorio: BaseRepositorio<Esporte>, IEsporteRepositorio
    {
        public EsporteRepositorio(ISportsPromoContexto contexto) : base(contexto)
        {
        }

        public override long Adicionar(Esporte instancia)
        {
            Contexto.Esportes.Add(instancia);

            Contexto.SaveChanges();

            return instancia.EsporteId;
        }
    }
}
