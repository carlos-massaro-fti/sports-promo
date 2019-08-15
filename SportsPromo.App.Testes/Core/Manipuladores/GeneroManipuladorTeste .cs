using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsPromo.App.Core.Modelos;
using SportsPromo.App.Dependencias;
using SportsPromo.App.Interfaces.Manipuladores;
using SportsPromo.Comum.Exceptions;
using Unity;


namespace SportsPromo.App.Testes.Core.Manipuladores
{
    [TestClass]
    public class GeneroManipuladorTeste
    {
        protected IUnityContainer Container { get; set; }

        protected IGeneroManipulador GeneroManipulador { get; set; }

        [TestInitialize()]
        public void GeneroManipuladorTesteInitialize()
        {
            Container = new UnityContainer();

            ConfigureTodos.Configure(Container);

            GeneroManipulador = Container.Resolve<IGeneroManipulador>();
        }

        [TestMethod]
        public void PegarTeste()
        {

            var instancia = new GeneroApp() { Nome = "Gênero Total" };
            try
            {
                var result = GeneroManipulador.Adicionar(instancia);

                Assert.IsTrue(result > 0);
            }
            catch (AppException ex)
            {
                Assert.IsTrue(ex.ValidationResults.Any());
            }


        }
    }
}
