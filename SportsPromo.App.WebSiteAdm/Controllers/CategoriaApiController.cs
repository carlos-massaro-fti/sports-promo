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
using SportsPromo.App.WebSiteAdm.Models;
using SportsPromo.Comum.Dados;
using SportsPromo.Comum.Exceptions;

namespace SportsPromo.App.WebSiteAdm.Controllers
{
    public class CategoriaApiController : ApiController
    {
        protected readonly ICategoriaManipulador CategoriaManipulador;

        public CategoriaApiController(ICategoriaManipulador categoriaManipulador)
        {
            CategoriaManipulador = categoriaManipulador;
        }

        // GET: api/CategoriaApps
        [HttpGet]
        [ActionName("Index")]
        public async Task<HttpResponseMessage> Index([FromUri] int? page, [FromUri] string sort, [FromUri] int? direction)
        {
            var consulta = new PaginadoOrdenado<CategoriaApp>()
            {
                PaginaAtual = page ?? 1,
                ItensPorPagina = 6,
                OrdemNome = sort ?? "Id",
                OrdemDirecao = direction ?? 0
            };

            var resultado = await CategoriaManipulador.ListarAsync(consulta);

            var response = Request.CreateResponse(HttpStatusCode.OK, resultado.Itens.ToList());

            response.Headers.Add("X-PAGE_SIZE", resultado.ItensPorPagina.ToString());

            response.Headers.Add("X-PAGE_CURRENT", resultado.PaginaAtual.ToString());

            response.Headers.Add("X-PAGE_COUNT", resultado.ContagemDePaginas.ToString());

            response.Headers.Add("X-ITEM_COUNT", resultado.ContagemDeLinhas.ToString());

            response.Headers.Add("X-SORT", resultado.OrdemNome);

            response.Headers.Add("X-SORT_DIRECTION", resultado.OrdemDirecao.ToString());

            return response;
        }

        // GET: api/CategoriaApps/5
        [HttpGet]
        [ResponseType(typeof(CategoriaApp))]
        public async Task<IHttpActionResult> Get(long id)
        {
            var resultado = await CategoriaManipulador.PegarAsync(id);

            if (resultado == null)
            {
                return NotFound();
            }

            return Ok(resultado);
        }

        // PUT: api/CategoriaApps/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCategoriaApp(long id, CategoriaApp categoriaApp)
        {
            throw new NotImplementedException();
            /*
                        if (!ModelState.IsValid)
                        {
                            return BadRequest(ModelState);
                        }

                        if (id != categoriaApp.Id)
                        {
                            return BadRequest();
                        }

                        db.Entry(categoriaApp).State = EntityState.Modified;

                        try
                        {
                            await db.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!EsporteAppExists(id))
                            {
                                return NotFound();
                            }
                            else
                            {
                                throw;
                            }
                        }
                        */
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CategoriaApps
        [HttpPost]
        [ResponseType(typeof(CategoriaApp))]
        public async Task<IHttpActionResult> Post([FromBody] CategoriaApp categoriaApp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var resultado = await CategoriaManipulador.AdicionarAsync(categoriaApp);
                    if (resultado > 0)
                    {
                        var resultadoModel = await CategoriaManipulador.PegarAsync(resultado);
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
            return InternalServerError();
        }

        // DELETE: api/CategoriaApps/5
        [ResponseType(typeof(CategoriaApp))]
        public async Task<IHttpActionResult> DeleteCategoriaApp(long id)
        {
            throw new NotImplementedException();
            /*
                        EsporteApp esporteApp = await db.CategoriaApps.FindAsync(id);
                        if (categoriaApp == null)
                        {
                            return NotFound();
                        }

                        db.EsporteApps.Remove(categoriaApp);
                        await db.SaveChangesAsync();

                        return Ok(categoriaApp);*/
        }
    }
}