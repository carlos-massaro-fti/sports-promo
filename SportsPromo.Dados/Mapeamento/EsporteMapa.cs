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
    public class EsporteMapa : EntityTypeConfiguration<Esporte>
    {
        public EsporteMapa()
        {
            ToTable("ESPORTE");

            HasKey(e => e.EsporteId);

            Property(e => e.EsporteId)
                .HasColumnName("ESPORTE_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.EsporteNome)
                .HasColumnName("ESPORTE_NOME")
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}
