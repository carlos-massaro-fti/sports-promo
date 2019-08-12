using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Dominio.Modelos
{
    public class Marco
    {
        public long MarcoID { get; set; }
        public decimal MarcoLat { get; set; }
        public decimal MarcoLon { get; set; }

        [ForeignKey("Prova")]
        public long MarcoProvaID { get; set; }
        public Prova Prova { get; set; }

        [ForeignKey("Receptor")]
        public long MarcoReceptorID { set; get; }
        public Receptor Receptor { set; get;  }

    }
}
