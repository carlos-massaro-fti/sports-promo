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
        DbSet<Categoria> Categorias { get; set; }
        DbSet<Equipe> Equipes { get; set; }
        DbSet<Esporte> Esportes { get; set; }
        DbSet<Marco> Marcos { get; set; }
        DbSet<Prova> Provas { get; set; }
        DbSet<Receptor> Receptores { get; set; }
        DbSet<Checagem> Checagems { get; set; }
        DbSet<Evento> Eventos { get; set; }

        DbSet<Usuario> Usuarios { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
