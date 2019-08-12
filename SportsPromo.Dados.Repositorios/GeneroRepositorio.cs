using SportsPromo.Dominio.Modelos;
using SportsPromo.Interfaces.Dados.Contextos;
using SportsPromo.Interfaces.Dados.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Dados.Repositorios
{
    public class GeneroRepositorio : BaseRepositorio<Genero>, IGeneroRepositorio
    {

        public GeneroRepositorio(ISportsPromoContexto contexto) : base(contexto)
        {
        }

        public override long Adicionar(Genero instancia)
        {
            Contexto.Generos.Add(instancia);

            Contexto.SaveChanges();

            return instancia.GeneroId;
        }
    }
}
