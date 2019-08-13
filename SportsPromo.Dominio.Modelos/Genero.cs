using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace SportsPromo.Dominio.Modelos
{
    public class Genero
    {
        public long GeneroId { get; set; }

        public string GeneroNome { get; set; }

        public virtual List<Inscricao> Inscricoes { get; set; }
    }
}
