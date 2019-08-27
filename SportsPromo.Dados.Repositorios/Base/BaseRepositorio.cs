using SportsPromo.Comum.Dados;
using SportsPromo.Dominio.Modelos;
using SportsPromo.Interfaces.Dados.Contextos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Dados.Repositorios
{
    public abstract class BaseRepositorio<T> where T : class
    {
        protected ISportsPromoContexto Contexto { get; }

      
        public BaseRepositorio(ISportsPromoContexto contexto)
        {
            Contexto = contexto;
        }

        public abstract long Adicionar(T instancia);

        public virtual bool Alterar(T instancia)
        {
            Contexto.Entry(instancia).State = EntityState.Modified;

            var result = Contexto.SaveChanges() > 0;

            return result;
        }

        public virtual bool Deletar(long id)
        {
            var instancia = Pegar(id);

            Contexto.Entry(instancia).State = EntityState.Deleted;

            var result = Contexto.SaveChanges() > 0;

            return result;
        }

        public virtual List<T> Listar()
        {
            var result = Contexto.Set<T>().ToList();

            return result;
        }

        public virtual T Pegar(long id)
        {
            var result = Contexto.Set<T>().Find(id);

            return result;
        }
    }
}
