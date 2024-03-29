﻿using SportsPromo.App.Interfaces.Manipuladores;
using SportsPromo.App.Core.Modelos;
using SportsPromo.Dominio.Modelos;
using SportsPromo.Interfaces.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.App.Core.Manipuladores
{
    public class GeneroManipulador : IGeneroManipulador
    {
        protected IGeneroServico GeneroServico { get; }


        public GeneroManipulador(IGeneroServico generoServico)
        {
            GeneroServico = generoServico;
        }
        public long Adicionar(GeneroApp instancia)
        {
            var modelInstancia = new Genero();
            modelInstancia.GeneroNome = instancia.Nome;
            var result = GeneroServico.Adicionar(modelInstancia);

            return result;
        }

        public bool Alterar(GeneroApp instancia)
        {
            var instanciaDominio = new Genero()
            {
                GeneroId = instancia.Id,
                GeneroNome = instancia.Nome
            };

            var result = GeneroServico.Alterar(instanciaDominio);

            return result;
        }

        public bool Deletar(long id)
        {
            throw new NotImplementedException();
        }

        public List<GeneroApp> Listar()
        {
            var domainResult = GeneroServico.Listar();

            var result = domainResult.Select(e => new GeneroApp()
            {
                Id = e.GeneroId,
                Nome = e.GeneroNome
            }).ToList();

            return result;
        }

        public GeneroApp Pegar(long id)
        {
            var resultDomain = GeneroServico.Pegar(id);

            var result = new GeneroApp()
            {

                Id = resultDomain.GeneroId,
                Nome = resultDomain.GeneroNome
            };

            return result;
        }

        public IEnumerable<ValidationResult> Validar(GeneroApp instancia)
        {
            throw new NotImplementedException();
        }
    }
}
