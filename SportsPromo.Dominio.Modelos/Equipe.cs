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
        public long EquipeId { get; set; }
        public string EquipeNome { get; set; }
        public long EquipeProvaId { get; set; }
        public Prova Prova { get; set; }

    }
}
