using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.App.Modelos
{
    public class ChecagemApp
    {
        public long Id { get; set; }

        [System.ComponentModel.DataAnnotations.Display(ShortName = "Rfid", Name = "Rfid")]
        public string Rfid { get; set; }
        public DateTime ChecadoEm { get; set; }
    }
}
