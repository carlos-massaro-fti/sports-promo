namespace SportsPromo.App.Core.Modelos
{
    public class CategoriaApp
    {
        public long Id { get; set; }

        [System.ComponentModel.DataAnnotations.Display(Name = "Nome da Categoria")]
        public string Nome { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Idade Minima")]
        public int IdadeMin { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Idade Maxima")]
        public int IdadeMax { get; set; }
    }
}
