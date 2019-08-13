using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsPromo.Dominio.Modelos
{
    public class Prova
    {
        public long ProvaId { get; set; }

        public long ProvaEsporteId { get; set; }

        public DateTime ProvaComecaEm { get; set; }

        public string ProvaEventoId { get; set; }

        public long ProvaEvento { get; set; }

        public virtual List<Marco> Marcos { get; set; }

        public virtual List<Equipe> Equipes { get; set; }

        public Evento Evento { get; set; }
    }
}