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
    [TestClass]
    public class ChecagemServicoTeste
    {
        protected IUnityContainer Container { get; set; }
        protected IChecagemServico ChecagemServico { get; set; }

        public ChecagemServicoTeste()
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
        public void EsporteServicoTesteInitialize()
        {

            Container = new UnityContainer();

            ConfigureTodos.Configure(Container);

            ChecagemServico = Container.Resolve<IChecagemServico>();


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

            var instancia = new Checagem() { ChecagemEm = DateTime.Now, ChecagemRfid="AISIM" };
            try
            {
                var result = ChecagemServico.Adicionar(instancia);

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

            var consulta = new PaginadoOrdenado<Checagem>()
            {
                ItensPorPagina = 4,
                PaginaAtual = 5
            };
            try
            {
                var result = ChecagemServico.Listar(consulta);

                Assert.IsTrue(result.Itens.Count() > 0);
            }
            catch (AppException ex)
            {
                Assert.IsTrue(ex.ValidationResults.Any());
            }
        }

    }
}
