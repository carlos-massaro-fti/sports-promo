using SportsPromo.Dados.Mapeamento;
using SportsPromo.Dominio.Modelos;
using SportsPromo.Interfaces.Dados.Contextos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Dados.Contextos
{
    public class SportsPromoContexto : DbContext, ISportsPromoContexto
    {

        public SportsPromoContexto() : base("SportsPromoConnection")
        {

        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Esporte> Esportes { get; set; }
        public DbSet<Marco> Marcos { get; set; }
        public DbSet<Prova> Provas { get; set; }
        public DbSet<Receptor> Receptores { get; set; }
        public DbSet<Checagem> Checagems { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Evento> Eventos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GeneroMapa());
            modelBuilder.Configurations.Add(new EsporteMapa());
            modelBuilder.Configurations.Add(new UsuarioMapa());
            modelBuilder.Configurations.Add(new ReceptorMapa());
            modelBuilder.Configurations.Add(new InscricaoMapa());
            modelBuilder.Configurations.Add(new MarcoMapa());
            modelBuilder.Configurations.Add(new CategoriaMapa());
            modelBuilder.Configurations.Add(new EquipeMapa());
            modelBuilder.Configurations.Add(new ChecagemMapa());
            modelBuilder.Configurations.Add(new ProvaTemCategoriaMapa());
        }
    }
}
