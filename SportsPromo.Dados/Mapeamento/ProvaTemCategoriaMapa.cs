using SportsPromo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Dados.Mapeamento
{
    public class ProvaTemCategoriaMapa: EntityTypeConfiguration<ProvaTemCategoria>
    {

        public ProvaTemCategoriaMapa() {
            ToTable("PROVA_TEM_CATEGORIA");

            HasKey(e => new { e.ProvaCategoriaId, e.CategoriaProvaId });
        }
    }
}
