using SportsPromo.App.Interfaces.Manipuladores;
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
    public class EsporteManipulador : IEsporteManipulador
    {
        protected IEsporteServico EsporteServico { get; }


        public EsporteManipulador(IEsporteServico esporteServico)
        {
            EsporteServico = esporteServico;
        }
        public long Adicionar(EsporteApp instancia)
        {
            var modelInstancia = new Esporte();

            modelInstancia.EsporteNome = instancia.Nome;

            var result = EsporteServico.Adicionar(modelInstancia);

            return result;
        }

        public bool Alterar(EsporteApp instancia)
        {
            throw new NotImplementedException();
        }

        public bool Deletar(long id)
        {
            throw new NotImplementedException();
        }

        public List<EsporteApp> Listar()
        {
            throw new NotImplementedException();
        }

        public EsporteApp Pegar(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ValidationResult> Validar(EsporteApp instancia)
        {
            throw new NotImplementedException();
        }
    }
}
