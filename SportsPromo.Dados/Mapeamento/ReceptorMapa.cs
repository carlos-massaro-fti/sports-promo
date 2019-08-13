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
    public class ReceptorMapa: EntityTypeConfiguration<Receptor>
    {
        public ReceptorMapa()
        {
            ToTable("RECEPTOR");

            HasKey(e => e.ReceptorId);

            Property(e => e.ReceptorId)
                .HasColumnName("RECEPTOR_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.ReceptorCodigo)
                .HasColumnName("RECEPTOR_CODIGO")
                .HasMaxLength(256)
                .IsRequired();

        }
    }
}
