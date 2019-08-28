using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SportsPromo.App.Core.Modelos;
using SportsPromo.App.Interfaces.Manipuladores;
using SportsPromo.App.Modelos;
using SportsPromo.App.WebSiteAdm.Models;
using SportsPromo.Comum.Dados;
using SportsPromo.Comum.Exceptions;

namespace SportsPromo.App.WebSiteAdm.Controllers
{
    public class ReceptorController : ApiController
    {
        protected readonly IReceptorManipulador ReceptorManipulador;

        public ReceptorController(IReceptorManipulador receptorManipulador)
        {
            ReceptorManipulador = receptorManipulador;
        }
        // GET: api/Receptor
        [HttpGet]
        [ActionName("Index")]
        public async Task<HttpResponseMessage> Index([FromUri] int? page, [FromUri] string sort, [FromUri] int? direction)
        {
            var consulta = new PaginadoOrdenado<ReceptorApp>()
            {
                PaginaAtual = page ?? 1,
                ItensPorPagina = 6,
                OrdemNome = sort ?? "Id",
                OrdemDirecao = direction ?? 0
            };

            var resultado = await ReceptorManipulador.ListarAsync(consulta);

            var response = Request.CreateResponse(HttpStatusCode.OK, resultado.Itens.ToList());

            response.Headers.Add("X-PAGE_SIZE", resultado.ItensPorPagina.ToString());

            response.Headers.Add("X-PAGE_CURRENT", resultado.PaginaAtual.ToString());

            response.Headers.Add("X-PAGE_COUNT", resultado.ContagemDePaginas.ToString());

            response.Headers.Add("X-ITEM_COUNT", resultado.ContagemDeLinhas.ToString());

            response.Headers.Add("X-SORT", resultado.OrdemNome);

            response.Headers.Add("X-SORT_DIRECTION", resultado.OrdemDirecao.ToString());

            return response;
        }

        // GET: api/Receptor/5
        [HttpGet]
        [ResponseType(typeof(ReceptorApp))]
        public async Task<IHttpActionResult> Get(long id)
        {
            var resultado = await ReceptorManipulador.PegarAsync(id);

            if (resultado == null)
            {
                return NotFound();
            }

            return Ok(resultado);
        }

        // POST: api/Receptor
        [HttpPost]
        [ResponseType(typeof(ReceptorApp))]
        public async Task<IHttpActionResult> Post([FromBody] ReceptorApp receptorApp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var resultado = await ReceptorManipulador.AdicionarAsync(receptorApp);
                    if (resultado > 0)
                    {
                        var resultadoModel = await ReceptorManipulador.PegarAsync(resultado);
                        return CreatedAtRoute("DefaultApi", new { action = "Get", id = resultado }, resultadoModel);
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
                                case "ReceptorCodigo":
                                    localName = "Codigo";
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
            return InternalServerError();
        }

        // PUT: api/Receptor/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Put([FromUri] long id ,  ReceptorApp receptorApp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    receptorApp.Id = id;

                    var resultado = await ReceptorManipulador.AlterarAsync(receptorApp);
                    if (resultado == true)
                    {
                        var resultadoModel = await ReceptorManipulador.PegarAsync(receptorApp.Id);
                        return Ok(resultadoModel);
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
                                case "ReceptorCodigo":
                                    localName = "Codigo";
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
            return InternalServerError();
        }

        // DELETE: api/Receptor/5
        public void Delete(int id)
        {
        }
    }
}
