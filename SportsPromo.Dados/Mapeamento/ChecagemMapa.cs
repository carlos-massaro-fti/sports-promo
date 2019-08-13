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
    public class ChecagemMapa : EntityTypeConfiguration<Checagem>
    {
        public ChecagemMapa()
        {
            ToTable("CHECAGEM");

            HasKey(e => e.ChecagemId);

            Property(e => e.ChecagemId)
                .HasColumnName("CHECAGEM_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.ChecagemEm)
                .HasColumnName("CHECAGEM_EM")
                .HasMaxLength(256)
                .IsRequired();

            Property(e => e.ChecagemRfid)
                .HasColumnName("CHECAGEM_RFID")
                .HasMaxLength(256)
                .IsRequired();

            HasRequired(e => e.Receptor)
                .WithMany(e => e.Checagens)
                .HasForeignKey(e => e.ChecagemReceptorId)
                .WillCascadeOnDelete(false);
                
        }
    }
}
