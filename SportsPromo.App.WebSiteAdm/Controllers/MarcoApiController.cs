using SportsPromo.App.Interfaces.Manipuladores;
using SportsPromo.App.Modelos;
using SportsPromo.Comum.Dados;
using SportsPromo.Comum.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace SportsPromo.App.WebSiteAdm.Controllers
{
    public class MarcoApiController:ApiController
    {
        protected readonly IMarcoManipulador MarcoManipulador;

        public MarcoApiController(IMarcoManipulador marcoManipulador)
        {
            MarcoManipulador = marcoManipulador;
        }

        // GET: api/MarcoApps
        [HttpGet]
        [ActionName("Index")]
        public async Task<HttpResponseMessage> Index([FromUri] int? page, [FromUri] string sort, [FromUri] int? direction)
        {
            var consulta = new PaginadoOrdenado<MarcoApp>()
            {
                PaginaAtual = page ?? 1,
                ItensPorPagina = 6,
                OrdemNome = sort ?? "Id",
                OrdemDirecao = direction ?? 0
            };

            var resultado = await MarcoManipulador.ListarAsync(consulta);

            var response = Request.CreateResponse(HttpStatusCode.OK, resultado.Itens.ToList());

            response.Headers.Add("X-PAGE_SIZE", resultado.ItensPorPagina.ToString());

            response.Headers.Add("X-PAGE_CURRENT", resultado.PaginaAtual.ToString());

            response.Headers.Add("X-PAGE_COUNT", resultado.ContagemDePaginas.ToString());

            response.Headers.Add("X-ITEM_COUNT", resultado.ContagemDeLinhas.ToString());

            response.Headers.Add("X-SORT", resultado.OrdemNome);

            response.Headers.Add("X-SORT_DIRECTION", resultado.OrdemDirecao.ToString());

            return response;
        }

        // GET: api/MarcoApps/5
        [HttpGet]
        [ResponseType(typeof(MarcoApp))]
        public async Task<IHttpActionResult> Get(long id)
        {
            var resultado = await MarcoManipulador.PegarAsync(id);

            if (resultado == null)
            {
                return NotFound();
            }

            return Ok(resultado);
        }

        // PUT: api/MarcoApps/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMarcoApp(long id, MarcoApp MarcoApp)
        {
            throw new NotImplementedException();
            /*
                        if (!ModelState.IsValid)
                        {
                            return BadRequest(ModelState);
                        }

                        if (id != MarcoApp.Id)
                        {
                            return BadRequest();
                        }

                        db.Entry(MarcoApp).State = EntityState.Modified;

                        try
                        {
                            await db.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!MarcoAppExists(id))
                            {
                                return NotFound();
                            }
                            else
                            {
                                throw;
                            }
                        }
                        
            return StatusCode(HttpStatusCode.NoContent);*/
        }

        // POST: api/MarcoApps
        [HttpPost]
        [ResponseType(typeof(MarcoApp))]
        public async Task<IHttpActionResult> Post([FromBody] MarcoApp MarcoApp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var resultado = await MarcoManipulador.AdicionarAsync(MarcoApp);
                    if (resultado > 0)
                    {
                        var resultadoModel = await MarcoManipulador.PegarAsync(resultado);
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
                                case "MarcoId":
                                    localName = "Id";
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

        // DELETE: api/MarcoApps/5
        [ResponseType(typeof(MarcoApp))]
        public async Task<IHttpActionResult> DeleteMarcoApp(long id)
        {
            throw new NotImplementedException();
            /*
                        MarcoApp MarcoApp = await db.MarcoApps.FindAsync(id);
                        if (MarcoApp == null)
                        {
                            return NotFound();
                        }

                        db.MarcoApps.Remove(MarcoApp);
                        await db.SaveChangesAsync();

                        return Ok(MarcoApp);*/
        }
    }
}