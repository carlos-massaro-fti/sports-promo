namespace SportsPromo.App.Modelos
{
   public  class ReceptorApp
    {
        public long Id { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Código do Receptor: ")]
        public string Codigo { get; set; }
    }
}
