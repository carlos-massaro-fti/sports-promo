using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Dominio.Modelos
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        public string CategoriaNome { get; set; }

        public int CategoriaIdadeMin { get; set; }

        public int CategoriaIdadeMax { get; set; }

        public int CategoriaGeneroId { get; set; }

        public Genero Genero { get; set; }
    }
}
