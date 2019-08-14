using SportsPromo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Interfaces.Dominio.Servicos
{
    interface IEquipeServico
    {
        List<Equipe> Listar();

        Equipe Pegar(long id);
        bool Deletar(long id);
        bool Alterar(Equipe instancia);
        long Adicionar(Equipe instancia);
    }
}
