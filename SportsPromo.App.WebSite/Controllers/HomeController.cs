using SportsPromo.App.Core.Modelos;
using SportsPromo.App.Interfaces.Manipuladores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
namespace SportsPromo.App.WebSite.Controllers
{
    public class HomeController : Controller
    {
        protected IGeneroManipulador GeneroManipulador { get; }
        public HomeController(IGeneroManipulador generoManipulador)
        {
            GeneroManipulador = generoManipulador;
        }
        public HomeController()
        {
            GeneroManipulador = DependencyResolver.Container.Resolve<IGeneroManipulador>();
        }
        public ActionResult Index()
        {
            return View();
        }


        [HandleError]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult GeneroAdicionar(GeneroApp model)
        {
            var dataResult = GeneroManipulador.Adicionar(model);

            ViewBag.Message = "Your contact page.";

            var resultStatus = string.Format("Adicionado com o Id:{0}", dataResult);

            var result = new HttpStatusCodeResult(200, resultStatus);
            return result;
            // return View();
        }
    }
}