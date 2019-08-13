using SportsPromo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Dados.Mapeamento
{
    public class ProvaMapa : EntityTypeConfiguration<Prova>
    {
        public ProvaMapa()
        {
            ToTable("PROVA");

            HasKey(e => e.ProvaId);

            Property(e => e.ProvaId)
                .HasColumnName("ESPORTE_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasMany(e => e.Marcos).WithRequired(e =>e.Prova).HasForeignKey(e =>e.MarcoProvaID);

            Property(e => e.ProvaComecaEm)
                .HasColumnName("PROVACOMECAEM")
                .IsRequired();

            HasRequired(e => e.ProvaEvento).WithRequiredDependent(e => e.ProvaEvento.);

        }
    }
}
