using SportsPromo.Dominio.Modelos;
using SportsPromo.Interfaces.Dados.Repositorios;
using SportsPromo.Interfaces.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Dominio.Servicos
{
    public class GeneroServico : IGeneroServico
    {
        protected IGeneroRepositorio GeneroRepositorio { get; }

        public GeneroServico(IGeneroRepositorio generoRepositorio)
        {
            GeneroRepositorio = generoRepositorio;
        }
        public long Adicionar(Genero instancia)
        {
            var result = GeneroRepositorio.Adicionar(instancia);

            return result;
        }

        public bool Alterar(Genero instancia)
        {
            var result = GeneroRepositorio.Alterar(instancia);

            return result;
        }

        public bool Deletar(long id)
        {
            var result = GeneroRepositorio.Deletar(id);

            return result;
        }

        public List<Genero> Listar()
        {
            var result = GeneroRepositorio.Listar();

            return result;
        }

        public Genero Pegar(long id)
        {
            var result = GeneroRepositorio.Pegar(id);

            return result;
        }
    }
}
