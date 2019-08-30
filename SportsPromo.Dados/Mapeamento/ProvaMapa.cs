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
                .HasColumnName("PROVA_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.ProvaEsporteId)
                .HasColumnName("PROVA_ESPORTE_ID")
                .IsRequired();

            Property(e => e.ProvaComecaEm)
                .HasColumnName("PROVA_COMECA_EM")
                .IsRequired();

            Property(e => e.ProvaLocal)
                .HasColumnName("PROVA_LOCAL")
                .IsRequired();

            Property(e => e.ProvaEventoId)
                .HasColumnName("PROVA_EVENTO_ID")
                .IsRequired();

            HasRequired(e => e.Esporte)
                .WithMany(e => e.Provas)
                .HasForeignKey(e => e.ProvaEsporteId)
                .WillCascadeOnDelete(false);

            HasRequired(e => e.Evento)
                .WithMany(e => e.Provas)
                .HasForeignKey(e => e.ProvaEventoId)
                .WillCascadeOnDelete(false);

            HasMany(e => e.Marcos)
                .WithRequired(e => e.Prova)
                .HasForeignKey(e => e.MarcoProvaId)
                .WillCascadeOnDelete(false);

            HasMany(e => e.Equipes)
                .WithRequired(e => e.Prova)
                .HasForeignKey(e => e.EquipeProvaId)
                .WillCascadeOnDelete(false);

            HasMany(e => e.ProvaTemCategorias)
                .WithRequired(e => e.Prova)
                .HasForeignKey(e => e.CategoriaProvaId)
                .WillCascadeOnDelete(false);
        }
    }
}
