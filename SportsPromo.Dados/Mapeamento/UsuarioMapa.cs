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
    public class UsuarioMapa : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMapa()
        {
            ToTable("USUARIO");

            HasKey(e => e.UsuarioId);

            Property(e => e.UsuarioId)
                .HasColumnName("USUARIO_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.UsuarioNome)
                .HasColumnName("USUARIO_NOME")
                .HasMaxLength(256)
                .IsRequired();

            Property(e => e.UsuarioEmail)
                .HasColumnName("USUARIO_EMAIL")
                .HasMaxLength(256)
                .IsRequired();

            Property(e => e.UsuarioSenha)
                .HasColumnName("USUARIO_SENHA")
                .HasMaxLength(256)
                .IsRequired();

            Property(e => e.UsuarioEhAtivado)
                .HasColumnName("USUARIO_EH_ATIVADO")
                .IsRequired();
        }
    }
}
