using SportsPromo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Interfaces.Dados.Repositorios
{
    public interface IGeneroRepositorio
    {
        List<Genero> Listar();
        Genero Pegar(long id);
        bool Deletar(long id);
        bool Alterar(Genero instancia);
        long Adicionar(Genero instancia);
    }
}
