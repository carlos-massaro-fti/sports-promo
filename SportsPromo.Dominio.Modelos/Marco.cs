using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Dominio.Modelos
{
    public class Marco
    {
        public long MarcoId { get; set; }
        [Required]
        public decimal MarcoLat { get; set; }
        [Required]
        public decimal MarcoLon { get; set; }

        [ForeignKey("Prova")][Required]
        public long MarcoProvaId { get; set; }
        public Prova Prova { get; set; }

        [ForeignKey("Receptor")][Required]
        public long MarcoReceptorId { set; get; }
        public Receptor Receptor { set; get;  }

    }
}
