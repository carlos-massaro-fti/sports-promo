using SportsPromo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Interfaces.Dados.Repositorios
{
    public interface IProvaRepositorio
    {
        List<Prova> Listar();
        Prova Pegar(long id);
        bool Deletar(long id);
        bool Alterar(Prova instancia);
        long Adicionar(Prova instancia);
    }
}
