using SportsPromo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Interfaces.Dados.Contextos
{
    public interface ISportsPromoContexto
    {
        DbSet<Genero> Generos { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
