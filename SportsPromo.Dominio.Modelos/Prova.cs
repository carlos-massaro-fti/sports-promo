using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsPromo.Dominio.Modelos
{
    public class Prova
    {
        public long ProvaId { get; set; }
        [ForeignKey("Esporte")]
        public long EsporteId { get; set; }
        public DateTime ProvaComecaEm { get; set; }
        public string Evento_Id { get; set; }
        [ForeignKey("Evento")]
        public long ProvaEvento { get; set; }
    }
}