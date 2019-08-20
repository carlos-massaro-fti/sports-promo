using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsPromo.App.Core.Modelos;
using SportsPromo.App.Dependencias;
using SportsPromo.App.Interfaces.Manipuladores;
using SportsPromo.Comum.Dados;
using SportsPromo.Comum.Exceptions;
using Unity;


namespace SportsPromo.App.Testes.Core.Manipuladores
{
    [TestClass]
    public class EsporteManipuladorTeste
    {
        protected IUnityContainer Container { get; set; }

        protected IEsporteManipulador EsporteManipulador { get; set; }

        [TestInitialize()]
        public void EsporteManipuladorTesteInitialize()
        {
            Container = new UnityContainer();

            ConfigureTodos.Configure(Container);

            EsporteManipulador = Container.Resolve<IEsporteManipulador>();
        }

        [TestMethod]
        public void PegarTeste()
        {
            var instancia = new EsporteApp() { Nome = "x" };
            try
            {
                var result = EsporteManipulador.Adicionar(instancia);

                Assert.IsTrue(result > 0);
            }
            catch (AppException ex)
            {
                Assert.IsTrue(ex.ValidationResults.Any());
            }
        }

        [TestMethod]
        public void ListarTeste()
        {

            var consulta = new PaginadoOrdenado<EsporteApp>()
            {
                ItensPorPagina = 4,
                PaginaAtual = 5
            };
            try
            {
                var result = EsporteManipulador.Listar(consulta);

                Assert.IsTrue(result.Itens.Count() > 0);
            }
            catch (AppException ex)
            {
                Assert.IsTrue(ex.ValidationResults.Any());
            }
        }
    }
}
