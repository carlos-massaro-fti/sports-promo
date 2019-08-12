using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Dominio.Modelos
{
     public class Equipe
    {
        public long EquipeID { get; set; }
        public string EquipeNome { get; set; }
        [ForeignKey("ProvaID")]
        public long EquipeProvaID { get; set; }
        public Prova ProvaID { get; set; }

    }
}
