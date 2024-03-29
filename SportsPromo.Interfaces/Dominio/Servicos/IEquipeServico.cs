﻿using SportsPromo.Comum.Dados;
using SportsPromo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Interfaces.Dominio.Servicos
{
    public interface IEquipeServico
    {
        PaginadoOrdenado<Equipe> Listar(PaginadoOrdenado<Equipe> consulta);
        List<Equipe> Listar();
        Equipe Pegar(long id);
        bool Deletar(long id);
        bool Alterar(Equipe instancia);
        long Adicionar(Equipe instancia);
        IEnumerable<ValidationResult> Validar(Equipe instancia);

        Task<PaginadoOrdenado<Equipe>> ListarAsync(PaginadoOrdenado<Equipe> consulta);
        Task<List<Equipe>> ListarAsync();
        Task<Equipe> PegarAsync(long id);
        Task<bool> DeletarAsync(long id);
        Task<bool> AlterarAsync(Equipe instancia);
        Task<long> AdicionarAsync(Equipe instancia);
        Task<IEnumerable<ValidationResult>> ValidarAsync(Equipe instancia);
    }
}
