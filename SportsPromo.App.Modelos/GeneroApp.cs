using System.ComponentModel.DataAnnotations;

namespace SportsPromo.App.Core.Modelos
{
    public class GeneroApp
    {
        public long Id { get; set; }
        [Required()]
        [MaxLength(256)]
        [MinLength(3)]
        public string Nome { get; set; }
    }
}
