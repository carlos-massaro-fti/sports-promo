using SportsPromo.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsPromo.Interfaces.Dominio.Servicos;
using SportsPromo.Interfaces.Dados.Repositorios;
using SportsPromo.Comum.Exceptions;
using System.ComponentModel.DataAnnotations;
using SportsPromo.Comum.Dados;

namespace SportsPromo.Dominio.Servicos
{
    public class MarcoServico : IMarcoServico
    {
        public IMarcoRepositorio MarcoRepositorio { get; }
        public MarcoServico(IMarcoRepositorio marcoRepositorio)
        {
            MarcoRepositorio = marcoRepositorio;
        }

        public long Adicionar(Marco instancia)
        {
            var validationResult = Validar(instancia);

            if (validationResult.Any())
            {
                throw new AppException(validationResult.First().ErrorMessage, validationResult);
            }

            var result = MarcoRepositorio.Adicionar(instancia);

            return result;
        }

        public bool Alterar(Marco instancia)
        {
            var atualInstancia = MarcoRepositorio.Pegar(instancia.MarcoId);

            Mesclar(atualInstancia, instancia);

            var validationResult = Validar(atualInstancia);

            if (validationResult.Any())
            {
                throw new AppException(validationResult.First().ErrorMessage, validationResult);
            }

            var result = MarcoRepositorio.Alterar(atualInstancia);

            return result;
        }
        private void Mesclar(Marco atualInstancia, Marco novaInstancia)
        {
            atualInstancia.MarcoLon = novaInstancia.MarcoLon;
            atualInstancia.MarcoLat = novaInstancia.MarcoLat;
        }

        public bool Deletar(long id)
        {

            var result = MarcoRepositorio.Deletar(id);

            return result;
        }

        public List<Marco> Listar()
        {
            var result = MarcoRepositorio.Listar();

            return result;
        }

        public Marco Pegar(long id)
        {
            var result = MarcoRepositorio.Pegar(id);

            return result;
        }

        public IEnumerable<ValidationResult> Validar(Marco instancia)
        {
            if (instancia.MarcoLat >= -90.00M || instancia.MarcoLat <= 90.00M)
            {
                yield return new ValidationResult("A Latitude não pode ter menos que -90 e mais que +90", new string[] { "MarcoLat" });
            }
            if (instancia.MarcoLon >= -180.00M || instancia.MarcoLat <= 180.00M)
            {
                yield return new ValidationResult("A Longitude não pode ter menos que -180 e mais que +180", new string[] { "MarcoLon" });
            }
        }

        public async Task<Marco> PegarAsync(long id)
        {
            var result = await MarcoRepositorio.PegarAsync(id);

            return result;
        }

        public async Task<List<Marco>> ListarAsync()
        {
            var result = await MarcoRepositorio.ListarAsync();

            return result;
        }

        public async Task<bool> AlterarAsync(Marco instancia)
        {
            var atualInstancia = await MarcoRepositorio.PegarAsync(instancia.MarcoId);

            Mesclar(atualInstancia, instancia);

            var validationResult = Validar(atualInstancia);

            if (validationResult.Any())
            {
                throw new AppException(validationResult.First().ErrorMessage, validationResult);
            }

            var result = MarcoRepositorio.Alterar(atualInstancia);

            return result;
        }

        public PaginadoOrdenado<Marco> Listar(PaginadoOrdenado<Marco> consulta)
        {
            throw new NotImplementedException();
        }

        public Task<PaginadoOrdenado<Marco>> ListarAsync(PaginadoOrdenado<Marco> consulta)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<long> AdicionarAsync(Marco instancia)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ValidationResult>> ValidarAsync(Marco instancia)
        {
            throw new NotImplementedException();
        }

        public PaginadoOrdenado<Esporte> Listar(PaginadoOrdenado<Esporte> consulta)
        {
            throw new NotImplementedException();
        }
    }
    }