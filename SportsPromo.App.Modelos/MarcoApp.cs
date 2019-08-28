using SportsPromo.Dominio.Modelos;
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
        public long Id { get; set; }
        
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public long ProvaId { get; set; }

        public Prova Prova { get; set; }

        public long ReceptorId { set; get; }

        public Receptor Receptor { set; get; }


    }
}
