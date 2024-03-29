﻿using System;
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
        public long EventoId { get; set; }

        public string EventoLocal { get; set; }

        public DateTime EventoDataInicio{ get; set; }

        public DateTime EventoDataFinal { get; set; }

        public virtual List<Prova> Provas { get; set; }
    }
}
