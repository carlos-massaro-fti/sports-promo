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
    public class EsporteController : Controller
    {

        protected readonly IEsporteManipulador EsporteManipulador;
        public EsporteController(IEsporteManipulador esporteManipulador)
        {
            EsporteManipulador = esporteManipulador;
        }
        public ActionResult OnePage()
        {
            return View();
        }


        // GET: EsporteApps
        public ActionResult Index(int? page, string sort, int? direction)
        {

            var consulta = new PaginadoOrdenado<EsporteApp>()
            {
                PaginaAtual = page ?? 1,
                ItensPorPagina = 6,
                OrdemNome = sort ?? "Id",
                OrdemDirecao = direction ?? 0
            };

           var result = EsporteManipulador.Listar(consulta);

            return View(result);
        }

        // GET: EsporteApps/Details/5
        public ActionResult Details(long? id)
        {



            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var EsporteApp = EsporteManipulador.Pegar(id.Value);

            if (EsporteApp == null)
            {
                return HttpNotFound();
            }
            return View(EsporteApp);
        }

        // GET: EsporteApps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EsporteApps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] EsporteApp EsporteApp)
        {
            if (ModelState.IsValid)
            {
                var result = EsporteManipulador.Adicionar(EsporteApp);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(EsporteApp);
        }

        // GET: EsporteApps/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var EsporteApp = EsporteManipulador.Pegar(id.Value);

            if (EsporteApp == null)
            {
                return HttpNotFound();
            }
            return View(EsporteApp);
        }

        // POST: EsporteApps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] EsporteApp esporteApp)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var result = EsporteManipulador.Alterar(esporteApp);
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
                                case "EsporteNome":
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
            return View(esporteApp);
        }

        // GET: EsporteApps/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var EsporteApp = EsporteManipulador.Pegar(id.Value);

            if (EsporteApp == null)
            {
                return HttpNotFound();
            }
            return View(EsporteApp);
        }

        // POST: EsporteApps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var result = EsporteManipulador.Deletar(id);

            return RedirectToAction("Index");
        }
    }
}
