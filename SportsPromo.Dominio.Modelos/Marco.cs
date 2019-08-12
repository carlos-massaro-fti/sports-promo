using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Dominio.Modelos
{
    public class Marco
    {
        public int MarcoId { get; set; }

        public decimal MarcoLat { get; set; }

        public decimal MarcoLon { get; set; }

        //public Prova Prova { get; set; }

        public int MarcoProvaId { get; set; }

        public Receptor Receptor { get; set; }

        public int MarcoReceptorId { get; set; }
    }
}
