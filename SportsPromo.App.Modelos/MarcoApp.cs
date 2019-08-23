using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.App.Modelos
{
    public class MarcoApp
    {
        [System.ComponentModel.DataAnnotations.Display(ShortName = "ID do Marco", Name = "ID do Marco")]
        public long Id { get; }
        
        public decimal MarcoLat { get; set; }
        public decimal MarcoLon { get; set; }
        public long MarcoProvaId { get; set; }

        public Prova Prova { get; set; }

        public long MarcoReceptorId { set; get; }

        public Receptor Receptor { set; get; }


    }
}
