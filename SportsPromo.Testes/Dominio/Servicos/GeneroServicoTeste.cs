using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;
using SportsPromo.Interfaces.Dominio.Servicos;
using SportsPromo.Dependencias;
using SportsPromo.Dominio.Modelos;
using SportsPromo.Comum.Exceptions;
using System.Linq;

namespace SportsPromo.Testes.Dominio.Servicos
{
    /// <summary>
    /// Summary description for MensagemServicoTeste
    /// </summary>
    [TestClass]
    public class GeneroServicoTeste
    {
        protected IUnityContainer Container { get; set; }
        protected IGeneroServico GeneroServico { get; set; }

        public GeneroServicoTeste()
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
        public void MensagemServicoTesteInitialize()
        {

            Container = new UnityContainer();

            ConfigureTodos.Configure(Container);

            GeneroServico = Container.Resolve<IGeneroServico>();


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

            var instancia = new Genero() { GeneroNome = "x" };
            try
            {
                var result = GeneroServico.Adicionar(instancia);

                Assert.IsTrue(result > 0);
            }
            catch (AppException ex) {
                Assert.IsTrue(ex.ValidationResults.Any());
            }
            

        }
    }
}
