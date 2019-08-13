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
    public class CategoriaMapa : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMapa()
        {
            ToTable("CATEGORIA");

            HasKey(e => e.CategoriaId);

            Property(e => e.CategoriaId)
                .HasColumnName("CATEGORIA_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.CategoriaNome)
                .HasColumnName("CATEGORIA_NOME")
                .HasMaxLength(256)
                .IsRequired();

            HasRequired(e => e.Genero)
                .WithMany(e => e.Categorias)
                .HasForeignKey(e => e.CategoriaGeneroId)
                .WillCascadeOnDelete(false);
        }
    }
}
