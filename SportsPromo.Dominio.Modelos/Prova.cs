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
        public string ProvaLocal { get; set; }
        public long ProvaEventoId { get; set; }
        public virtual List<Marco> Marcos { get; set; }
        public virtual List<Equipe> Equipes { get; set; }
        public virtual List<ProvaTemCategoria> ProvaTemCategorias { get; set; }
        public virtual Esporte Esporte { get; set; }
        public virtual Evento Evento { get; set; }
    }
}