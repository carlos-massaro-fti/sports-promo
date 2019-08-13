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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new GeneroMapa());
            modelBuilder.Configurations.Add(new EsporteMapa());
            modelBuilder.Configurations.Add(new ReceptorMapa());

            //modelBuilder.Types<Genero>().Configure(e =>
            //{
            //    e.ToTable("");
            //    e.Property(x => x.GeneroId).HasColumnName("GENERO_ID");

            //});

        }
    }
}
