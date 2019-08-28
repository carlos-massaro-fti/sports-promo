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
using SportsPromo.Comum.Dados;
using SportsPromo.Comum.Exceptions;
using SportsPromo.Comum.Helpers;

namespace SportsPromo.App.WebSiteAdm.Controllers
{
    public class CategoriaController : Controller
    {
        protected readonly ICategoriaManipulador CategoriaManipulador;
        public CategoriaController(ICategoriaManipulador categoriaManipulador)
        {
            CategoriaManipulador = categoriaManipulador;
        }
        public ActionResult OnePage()
        {
            return View();
        }


        // GET: CategoriaApps
        public ActionResult Index(int? page, string sort, int? direction)
        {

            var consulta = new PaginadoOrdenado<CategoriaApp>()
            {
                PaginaAtual = page ?? 1,
                ItensPorPagina = 6,
                OrdemNome = sort ?? "Id",
                OrdemDirecao = direction ?? 0
            };

            var result = CategoriaManipulador.Listar(consulta);

            return View(result);
        }

        // GET: CategoriaApps/Details/5
        public ActionResult Details(long? id)
        {



            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var CategoriaApp = CategoriaManipulador.Pegar(id.Value);

            if (CategoriaApp == null)
            {
                return HttpNotFound();
            }
            return View(CategoriaApp);
        }

        // GET: CategoriaApps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaApps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] CategoriaApp CategoriaApp)
        {
            if (ModelState.IsValid)
            {
                var result = CategoriaManipulador.Adicionar(CategoriaApp);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(CategoriaApp);
        }

        // GET: CategoriaApps/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var CategoriaApp = CategoriaManipulador.Pegar(id.Value);

            if (CategoriaApp == null)
            {
                return HttpNotFound();
            }
            return View(CategoriaApp);
        }

        // POST: CategoriaApps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] CategoriaApp CategoriaApp)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var result = CategoriaManipulador.Alterar(CategoriaApp);
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
                                case "CategoriaNome":
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
            return View(CategoriaApp);
        }

        // GET: CategoriaApps/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var CategoriaApp = CategoriaManipulador.Pegar(id.Value);

            if (CategoriaApp == null)
            {
                return HttpNotFound();
            }
            return View(CategoriaApp);
        }

        // POST: CategoriaApps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var result = CategoriaManipulador.Deletar(id);

            return RedirectToAction("Index");
        }
    }
}