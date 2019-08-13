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
    class EquipeMapa : EntityTypeConfiguration<Equipe>
    {
        public EquipeMapa()
        {
            ToTable("EQUIPE");

            HasKey(e => e.EquipeId);

            Property(e => e.EquipeId)
                .HasColumnName("EQUIPE_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.EquipeNome)
                .HasColumnName("EQUIPE_NOME")
                .HasMaxLength(256)
                .IsRequired();

            HasRequired(e => e.Prova)
                .WithMany(e => e.Equipes)
                .HasForeignKey(e => e.EquipeProvaId)
                .WillCascadeOnDelete(false);
    }
    }
}
