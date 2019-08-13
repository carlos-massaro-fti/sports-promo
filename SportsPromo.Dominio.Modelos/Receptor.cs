using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Dominio.Modelos
{
    public class Receptor
    {
        public long ReceptorId { get; set; }

        public string ReceptorCodigo { get; set; }
        public virtual List<Checagem> Checagens { get; set; }
    }
}
