using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsPromo.App.WebSiteAdm.Controllers
{
    public class MarcoController :Controller
    {
        public ActionResult Index()
        {
            return View("OnePage");
        }
    }
}