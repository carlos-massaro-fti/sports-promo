namespace SportsPromo.App.Core.Modelos
{
    public class EsporteApp
    {
        public long Id { get; set; }

        [System.ComponentModel.DataAnnotations.Display(ShortName = "Nome do Esporte", Name = "Nome do Esporte")]
        public string Nome { get; set; }
    }
}
