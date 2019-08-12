using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Dominio.Modelos
{
    [Table("EVENTO")]
    public class Evento
    {
        [Required]
        public int Evento_Id { get; set; }
        public string Evento_Local { get; set; }
        public DateTime Evento_Data_Nascimento { get; set; }
        public DateTime Evento_Data_Final { get; set; }
    }
}
