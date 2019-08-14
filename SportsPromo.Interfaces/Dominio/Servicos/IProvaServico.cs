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
    public interface IProvaServico
    {
        IProvaRepositorio ProvaRepositorio { get; }
        List<Prova> Listar();
        Prova Pegar(long id);
        bool Deletar(long id);
        bool Alterar(Prova instancia);
        long Adicionar(Prova instancia);
        IEnumerable<ValidationResult> Validar(Prova instancia);
    }
}
