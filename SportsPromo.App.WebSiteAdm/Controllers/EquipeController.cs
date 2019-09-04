using SportsPromo.App.Interfaces.Manipuladores;
using SportsPromo.App.Modelos;
using SportsPromo.Comum.Dados;
using SportsPromo.Comum.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace SportsPromo.App.WebSiteAdm.Controllers
{
    public class EquipeController : Controller
    {
        public ActionResult Index()
        {
            return View("OnePage");
        }
    }
}