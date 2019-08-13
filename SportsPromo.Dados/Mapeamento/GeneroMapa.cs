using SportsPromo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsPromo.Dados.Mapeamento
{
    public class GeneroMapa : EntityTypeConfiguration<Genero>
    {
        public GeneroMapa()
        {
            ToTable("GENERO");

            HasKey(e => e.GeneroId);

            Property(e => e.GeneroId)
                .HasColumnName("GENERO_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.GeneroNome)
                .HasColumnName("GENERO_NOME")
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}
