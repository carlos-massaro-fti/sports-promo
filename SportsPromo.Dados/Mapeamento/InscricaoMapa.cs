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
    public class InscricaoMapa : EntityTypeConfiguration<Inscricao>
    {
        public InscricaoMapa()
        {
            ToTable("INSCRICAO");

            HasKey(e => e.InscricaoId);

            Property(e => e.InscricaoId)
                .HasColumnName("INSCRICAO_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.InscricaoNome)
                .HasColumnName("INSCRICAO_NOME")
                .HasMaxLength(256)
                .IsRequired();

            Property(e => e.InscricaoEmail)
                .HasColumnName("INSCRICAO_EMAIL")
                .HasMaxLength(256)
                .IsRequired();

            Property(e => e.InscricaoNascimento)
                .HasColumnName("INSCRICAO_NASCIMENTO")
                .IsRequired();

            Property(e => e.InscricaoEquipeId)
               .HasColumnName("INSCRICAO_NASCIMENTO")
               .IsRequired();

            Property(e => e.InscricaoGeneroId)
               .HasColumnName("INSCRICAO_NASCIMENTO")
               .IsRequired();

            Property(e => e.InscricaoRFID)
                .HasColumnName("INSCRICAO_RFID")
                .HasMaxLength(256)
                .IsRequired();

            HasRequired(e => e.Genero)
                 .WithMany(e => e.Inscricoes)
                 .HasForeignKey(e => e.InscricaoGeneroId)
                 .WillCascadeOnDelete(false);

            HasRequired(e => e.Genero)
                 .WithMany(e => e.Inscricoes)
                 .HasForeignKey(e => e.InscricaoGeneroId)
                 .WillCascadeOnDelete(false);

            HasRequired(e => e.Equipe)
                .WithMany(e => e.Inscricoes)
                .HasForeignKey(e => e.InscricaoEquipeId)
                .WillCascadeOnDelete(false);
        }
    }
}
