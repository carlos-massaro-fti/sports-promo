using SportsPromo.Comum.Dados;
using SportsPromo.Dominio.Modelos;
using SportsPromo.Interfaces.Dados.Contextos;
using SportsPromo.Interfaces.Dados.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Dados.Repositorios
{
    public class ChecagemRepositorio : BaseRepositorio<Checagem>, IChecagemRepositorio
    {
        public ChecagemRepositorio(ISportsPromoContexto contexto) : base(contexto)
        {
        }

        public override long Adicionar(Checagem instancia)
        {
            Contexto.Checagems.Add(instancia);

            Contexto.SaveChanges();

            return instancia.ChecagemId;
        }
        public Task<long> AdicionarAsync(Checagem instancia)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AlterarAsync(Checagem instancia)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarAsync(long id)
        {
            throw new NotImplementedException();
        }

        public PaginadoOrdenado<Checagem> Listar(PaginadoOrdenado<Checagem> consulta)
        {
            throw new NotImplementedException();
        }

        public Task<PaginadoOrdenado<Checagem>> ListarAsync(PaginadoOrdenado<Checagem> consulta)
        {
            throw new NotImplementedException();
        }

        public Task<List<Checagem>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Checagem> PegarAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
