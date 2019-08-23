using SportsPromo.Comum.Dados;
using SportsPromo.Comum.Exceptions;
using SportsPromo.Dominio.Modelos;
using SportsPromo.Interfaces.Dados.Repositorios;
using SportsPromo.Interfaces.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsPromo.Dominio.Servicos
{
    public class EventoServico : IEventoServico
    {
        public IEventoRepositorio EventoRepositorio { get; }

        public EventoServico(IEventoRepositorio eventoRepositorio)
        {
            EventoRepositorio = eventoRepositorio;
        }

        public long Adicionar(Evento instancia)
        {
            var validationResult = Validar(instancia);

            if (validationResult.Any())
            {
                throw new AppException(validationResult.First().ErrorMessage, validationResult);
            }

            var result = EventoRepositorio.Adicionar(instancia);

            return result;
        }

        public bool Alterar(Evento instancia)
        {
            var atualInstancia = EventoRepositorio.Pegar(instancia.EventoId);

            Mesclar(atualInstancia, instancia);

            var validationResult = Validar(atualInstancia);

            if (validationResult.Any())
            {
                throw new AppException(validationResult.First().ErrorMessage, validationResult);
            }

            var result = EventoRepositorio.Alterar(atualInstancia);

            return result;
        }

        private void Mesclar(Evento atualInstancia, Evento novaInstancia)
        {
            atualInstancia.EventoDataInicio = novaInstancia.EventoDataInicio;
        }

        public bool Deletar(long id)
        {
            var result = EventoRepositorio.Deletar(id);

            return result;
        }

        public List<Evento> Listar()
        {
            var result = EventoRepositorio.Listar();

            return result;
        }

        public Evento Pegar(long id)
        {
            var result = EventoRepositorio.Pegar(id);

            return result;
        }

        public IEnumerable<ValidationResult> Validar(Evento instancia)
        {
            if (instancia.EventoDataInicio > instancia.EventoDataFinal)
            {
                yield return new ValidationResult("O nome do esporte não pode ter mais de 256 caracteres", new string[] { "EventoDataFinal" , "EventoDataInicio"});
            }
            
        }

        public PaginadoOrdenado<Evento> Listar(PaginadoOrdenado<Evento> consulta)
        {
            var result = EventoRepositorio.Listar(consulta);

            return result;
        }

        public async Task<PaginadoOrdenado<Evento>> ListarAsync(PaginadoOrdenado<Evento> consulta)
        {
            var resultado = await EventoRepositorio.ListarAsync(consulta);

            return resultado;
        }

        public Task<List<Evento>> ListarAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Evento> PegarAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AlterarAsync(Evento instancia)
        {
            throw new NotImplementedException();
        }

        public async Task<long> AdicionarAsync(Evento instancia)
        {
            var resultado = await EventoRepositorio.AdicionarAsync(instancia);

            return resultado;
        }

        public async Task<IEnumerable<ValidationResult>> ValidarAsync(Evento instancia)
        {
            throw new NotImplementedException();
        }
    }
}
