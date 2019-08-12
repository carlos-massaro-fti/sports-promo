using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Dominio.Modelos
{
    class Checagem
    {
        public long ChecagemId { get; set; }
        public long ChecagemReceptorId { get; set; }
        public string ChecagemEm { get; set; }
        public string ChecagemRfid { get; set; }
    }
}
