using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Dominio.Modelos
{
    class Equipe
    {
        public long EquipeID { get; set; }

        public string EquipeNome { get; set; }
        [ForeignKey("IdProva")]
        public long EquipeProvaID { get; set; }
    }
}
