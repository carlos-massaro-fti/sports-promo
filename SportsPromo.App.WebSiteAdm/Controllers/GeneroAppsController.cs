using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SportsPromo.App.Core.Modelos;
using SportsPromo.App.Interfaces.Manipuladores;
using SportsPromo.App.WebSiteAdm.Models;
using SportsPromo.Comum.Exceptions;
using SportsPromo.Comum.Helpers;

namespace SportsPromo.App.WebSiteAdm.Controllers
{
    public class GeneroAppsController : Controller
    {

        protected readonly IGeneroManipulador GeneroManipulador;
        public GeneroAppsController(IGeneroManipulador generoManipulador)
        {
            GeneroManipulador = generoManipulador;
        }

        // GET: GeneroApps
        public ActionResult Index()
        {
            var result = GeneroManipulador.Listar();

            return View(result);
        }

        // GET: GeneroApps/Details/5
        public ActionResult Details(long? id)
        {



            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var generoApp = GeneroManipulador.Pegar(id.Value);

            if (generoApp == null)
            {
                return HttpNotFound();
            }
            return View(generoApp);
        }

        // GET: GeneroApps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GeneroApps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] GeneroApp generoApp)
        {
            if (ModelState.IsValid)
            {
                var result = GeneroManipulador.Adicionar(generoApp);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(generoApp);
        }

        // GET: GeneroApps/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var generoApp = GeneroManipulador.Pegar(id.Value);

            if (generoApp == null)
            {
                return HttpNotFound();
            }
            return View(generoApp);
        }

        // POST: GeneroApps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] GeneroApp generoApp)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var result = GeneroManipulador.Alterar(generoApp);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (AppException ex)
                {

                    ex.ValidationResults.ToList().ForEach(e =>
                    {
                        var localName = string.Empty;

                        if (e.MemberNames.Any())
                        {
                            var memberName = e.MemberNames.First();
                            switch (memberName)
                            {
                                case "GeneroNome":
                                    localName = "Nome";
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (string.IsNullOrEmpty(localName))
                        {
                            ModelState.AddModelError(string.Empty, e.ErrorMessage);
                        }
                        else
                        {
                            ModelState.AddModelError(localName, e.ErrorMessage);
                        }
                    });
                    ModelState.AddModelError(string.Empty, "Problemas ao Alterar!");

                }
            }
            return View(generoApp);
        }

        // GET: GeneroApps/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var generoApp = GeneroManipulador.Pegar(id.Value);

            if (generoApp == null)
            {
                return HttpNotFound();
            }
            return View(generoApp);
        }

        // POST: GeneroApps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var result = GeneroManipulador.Deletar(id);

            return RedirectToAction("Index");
        }
    }
}
