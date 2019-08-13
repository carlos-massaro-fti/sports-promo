using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsPromo.Dominio.Modelos
{
    public class Prova
    {
        public long ProvaId { get; set; }
        [ForeignKey("Esporte")]
        public long EsporteId { get; set; }
        public DateTime ProvaComecaEm { get; set; }
        public string EventoId { get; set; }
        [ForeignKey("Evento")]
        public long ProvaEvento { get; set; }
        public virtual List<Marco> Marcos { get; set; }

        public virtual List<Equipe> Equipes { get; set; }
    }
}