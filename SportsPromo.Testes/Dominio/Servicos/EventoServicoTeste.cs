using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsPromo.Comum.Dados;
using SportsPromo.Comum.Exceptions;
using SportsPromo.Dependencias;
using SportsPromo.Dominio.Modelos;
using SportsPromo.Interfaces.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace SportsPromo.Testes.Dominio.Servicos
{
    /// <summary>
    /// Summary description for MensagemServicoTeste
    /// </summary>
    [TestClass]
    public class EventoServicoTeste
    {
        protected IUnityContainer Container { get; set; }
        protected IEventoServico EventoServico { get; set; }

        public EventoServicoTeste()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext) { }

        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void EventoServicoTesteInitialize()
        {

            Container = new UnityContainer();

            ConfigureTodos.Configure(Container);

            EventoServico = Container.Resolve<IEventoServico>();


        }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void PegarTeste()
        {

            var instancia = new Evento() { EventoNome = "Meia Maratona" };
            try
            {
                var result = EventoServico.Adicionar(instancia);

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

            var consulta = new PaginadoOrdenado<Evento>()
            {
                ItensPorPagina = 4,
                PaginaAtual = 5
            };
            try
            {
                var result = EventoServico.Listar(consulta);

                Assert.IsTrue(result.Itens.Count() > 0);
            }
            catch (AppException ex)
            {
                Assert.IsTrue(ex.ValidationResults.Any());
            }
        }

    }
}
