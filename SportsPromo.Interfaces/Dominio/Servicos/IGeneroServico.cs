using SportsPromo.Dominio.Modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SportsPromo.Interfaces.Dados.Repositorios;

namespace SportsPromo.Interfaces.Dominio.Servicos
{
    public interface IGeneroServico
    {
        IGeneroRepositorio GeneroRepositorio { get; }
        List<Genero> Listar();
        Genero Pegar(long id);
        bool Deletar(long id);
        bool Alterar(Genero instancia);
        long Adicionar(Genero instancia);
        IEnumerable<ValidationResult> Validar(Genero instancia);
    }
}
