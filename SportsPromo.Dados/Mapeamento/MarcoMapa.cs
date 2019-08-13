using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using SportsPromo.Dominio.Modelos;

namespace SportsPromo.Dados.Mapeamento
{
    public class MarcoMapa : EntityTypeConfiguration<Marco>
    {
        public MarcoMapa()
        {
            ToTable("MARCO");

            HasKey(e => e.MarcoId);

            Property(e => e.MarcoId)
                .HasColumnName("MARCO_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.MarcoLat)
                .HasColumnName("MARCO_LAT")
                .HasPrecision(20,8)
                .IsRequired();

            Property(e => e.MarcoLon)
                .HasColumnName("MARCO_LON")
                .HasPrecision(20, 8)
                .IsRequired();

            HasRequired(e => e.Receptor).WithMany(e => e.Marcos)
                .HasForeignKey(e => e.MarcoReceptorId)
                .WillCascadeOnDelete(false);

            HasRequired(e => e.Prova).WithMany(e => e.Marcos)
                .HasForeignKey(e => e.MarcoProvaId)
                .WillCascadeOnDelete(false);

        }
    }
}
