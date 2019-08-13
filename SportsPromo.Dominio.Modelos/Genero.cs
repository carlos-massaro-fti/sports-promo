using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SportsPromo.Dominio.Modelos
{
    [Table("GENERO")]
    public class Genero
    {
        //[Column("GENERO_ID")]
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long GeneroId { get; set; }

        [Column("GENERO_NOME")]
        public string GeneroNome { get; set; }
    }
}
