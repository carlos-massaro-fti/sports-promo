using SportsPromo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Interfaces.Dados.Repositorios
{
    public interface IEsporteRepositorio
    {
        List<Esporte> Listar();
        Esporte Pegar(long id);
        bool Deletar(long id);
        bool Alterar(Esporte instancia);
        long Adicionar(Esporte instancia);
    }
}
