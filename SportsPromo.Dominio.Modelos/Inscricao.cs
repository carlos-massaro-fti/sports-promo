using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Dominio.Modelos
{
    public class Inscricao
    {
        public int InscricaoId { get; set; }

        public string InscricaoNome { get; set; }

        public string InscricaoEmail { get; set; }

        public DateTime InscricaoNascimento { get; set; }

        public string InscricaoRFID { get; set; }

        public int InscricaoEquipeId { get; set; }

        public int InscricaoGeneroId { get; set; }

        //public Equipe Equipe { get; set; }

        public Genero Genero { get; set; }
    }
}
