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

        public decimal MarcoLat { get; set; }

        public decimal MarcoLon { get; set; }

        public long MarcoProvaId { get; set; }

        public Prova Prova { get; set; }

        public long MarcoReceptorId { set; get; }

        public Receptor Receptor { set; get;  }

    }
}
