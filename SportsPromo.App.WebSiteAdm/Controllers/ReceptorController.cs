﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace SportsPromo.App.WebSiteAdm.Controllers
{
    public class ReceptorController : Controller
    {
        public ActionResult Index()
        {
            return View("OnePage");
        }
    }
}
