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
    public class ChecagemController : Controller
    {
        protected readonly IChecagemManipulador ChecagemManipulador;
        public ChecagemController(IChecagemManipulador checagemManipulador)
        {
            ChecagemManipulador = checagemManipulador;
        }
        public ActionResult OnePage()
        {
            return View();
        }


        // GET: ChecagemApps
        public ActionResult Index(int? page, string sort, int? direction)
        {

            var consulta = new PaginadoOrdenado<ChecagemApp>()
            {
                PaginaAtual = page ?? 1,
                ItensPorPagina = 6,
                OrdemNome = sort ?? "Id",
                OrdemDirecao = direction ?? 0
            };

            var result = ChecagemManipulador.Listar(consulta);

            return View(result);
        }

        // GET: ChecagemApps/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ChecagemApp = ChecagemManipulador.Pegar(id.Value);

            if (ChecagemApp == null)
            {
                return HttpNotFound();
            }
            return View(ChecagemApp);
        }

        // GET: ChecagemApps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChecagemApps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rfid")] ChecagemApp ChecagemApp)
        {
            if (ModelState.IsValid)
            {
                var result = ChecagemManipulador.Adicionar(ChecagemApp);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(ChecagemApp);
        }

        // GET: ChecagemApps/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ChecagemApp = ChecagemManipulador.Pegar(id.Value);

            if (ChecagemApp == null)
            {
                return HttpNotFound();
            }
            return View(ChecagemApp);
        }

        // POST: ChecagemApps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Http.HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Rfid")] ChecagemApp checagemApp)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var result = ChecagemManipulador.Alterar(checagemApp);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                }
                catch (AppException ex)
                {

                    ex.ValidationResults.ToList().ForEach(e =>
                    {
                        var localRfid = string.Empty;

                        if (e.MemberNames.Any())
                        {
                            var memberName = e.MemberNames.First();
                            switch (memberName)
                            {
                                case "ChecagemRfid":
                                    localRfid = "Rfid";
                                    break;
                                default:
                                    break;
                            }
                        }
                        if (string.IsNullOrEmpty(localRfid))
                        {
                            ModelState.AddModelError(string.Empty, e.ErrorMessage);
                        }
                        else
                        {
                            ModelState.AddModelError(localRfid, e.ErrorMessage);
                        }
                    });
                    ModelState.AddModelError(string.Empty, "Problemas ao Alterar!");

                }
            }
            return View(checagemApp);
        }

        // GET: ChecagemApps/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ChecagemApp = ChecagemManipulador.Pegar(id.Value);

            if (ChecagemApp == null)
            {
                return HttpNotFound();
            }
            return View(ChecagemApp);
        }

        // POST: EsporteApps/Delete/5
        [System.Web.Http.HttpPost, System.Web.Http.ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var result = ChecagemManipulador.Deletar(id);

            return RedirectToAction("Index");
        }
    }
}
