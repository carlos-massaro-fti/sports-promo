﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsPromo.Dominio.Modelos
{
    public class Prova
    {
        public long ProvaId { get; set; }
        [ForeignKey("Esporte")]
        public long ProvaEsporteId { get; set; }
        public DateTime ProvaComecaEm { get; set; }
        public string ProvaEventoId { get; set; }
        [ForeignKey("Evento")]
        public long ProvaEvento { get; set; }

        public Evento Evento { get; set; }
    }
}