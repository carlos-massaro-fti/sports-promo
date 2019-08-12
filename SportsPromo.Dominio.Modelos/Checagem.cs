using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Dominio.Modelos
{
    public class Checagem
    {
        public long ChecagemId { get; set; }
        [ForeignKey("Receptor")]
        public long ChecagemReceptorId { get; set; }
        public Receptor Receptor { get; set; }
        public string ChecagemEm { get; set; }
        public string ChecagemRfid { get; set; }
    }
}
