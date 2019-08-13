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
    public class EventoMapa : EntityTypeConfiguration<Evento>
    {
        public EventoMapa()
        {
            ToTable("EVENTO");

            HasKey(e => e.EventoId);

            Property(e => e.EventoId)
                    .HasColumnName("EVENTO_ID")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.EventoLocal)
                    .HasColumnName("EVENTO_LOCAL")
                    .HasMaxLength(256)
                    .IsRequired();

            Property(e => e.EventoDataInicio)
                    .HasColumnName("DATA_INICIO")
                    .IsRequired();

            Property(e => e.EventoDataFinal)
                     .HasColumnName("DATA_FINAL")
                     .IsRequired();

        }
    }
}
