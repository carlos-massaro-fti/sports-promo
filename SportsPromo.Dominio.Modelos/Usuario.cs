using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Dominio.Modelos
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        public string UsuarioNome { get; set; }

        public string UsuarioEmail { get; set; }

        public bool UsuarioEhAtivado { get; set; }

        public string UsuarioSenha { get; set; }
    }
}
