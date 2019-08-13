using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsPromo.Dominio.Modelos
{
    public class ProvaTemCategoria
    {
        public long ProvaCategoriaId { get; set; }
        public long CategoriaProvaId { get; set; }
        public virtual Prova Prova { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}