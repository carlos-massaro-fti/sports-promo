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
    public class EventoMapa: EntityTypeConfiguration<Evento>
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
                .HasMaxLength(256);

            Property(e => e.EventoDataFinal)
                .HasColumnName("EVENTO_DATA_FINAL");

            Property(e => e.EventoDataInicio)
              .HasColumnName("EVENTO_DATA_INICIO");

            HasMany(e => e.Provas)
                .WithRequired(e => e.Evento)
                .HasForeignKey(e => e.ProvaEventoId)
                .WillCascadeOnDelete(false);
        }
    }
}
