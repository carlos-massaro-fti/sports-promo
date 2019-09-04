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
using System.Web.Http;
using System.Web.Http.Description;

namespace SportsPromo.App.WebSiteAdm.Controllers
{
    public class EquipeApiController : ApiController
    {
        protected readonly IEquipeManipulador EquipeManipulador;

        public EquipeApiController(IEquipeManipulador equipeManipulador)
        {
            EquipeManipulador = equipeManipulador;
        }

        // GET: api/EsporteApps
        [HttpGet]
        [ActionName("Index")]
        public async Task<HttpResponseMessage> Index([FromUri] int? page, [FromUri] string sort, [FromUri] int? direction)
        {
            var consulta = new PaginadoOrdenado<EquipeApp>()
            {
                PaginaAtual = page ?? 1,
                ItensPorPagina = 6,
                OrdemNome = sort ?? "Id",
                OrdemDirecao = direction ?? 0
            };

            var resultado = await EquipeManipulador.ListarAsync(consulta);

            var response = Request.CreateResponse(HttpStatusCode.OK, resultado.Itens.ToList());

            response.Headers.Add("X-PAGE_SIZE", resultado.ItensPorPagina.ToString());

            response.Headers.Add("X-PAGE_CURRENT", resultado.PaginaAtual.ToString());

            response.Headers.Add("X-PAGE_COUNT", resultado.ContagemDePaginas.ToString());

            response.Headers.Add("X-ITEM_COUNT", resultado.ContagemDeLinhas.ToString());

            response.Headers.Add("X-SORT", resultado.OrdemNome);

            response.Headers.Add("X-SORT_DIRECTION", resultado.OrdemDirecao.ToString());

            return response;
        }

        // GET: api/EsporteApps/5
        [HttpGet]
        [ResponseType(typeof(EquipeApp))]
        public async Task<IHttpActionResult> Get(long id)
        {
            var resultado = await EquipeManipulador.PegarAsync(id);

            if (resultado == null)
            {
                return NotFound();
            }

            return Ok(resultado);
        }


        // POST: api/EsporteApps
        [HttpPost]
        [ResponseType(typeof(EquipeApp))]
        public async Task<IHttpActionResult> Post([FromBody] EquipeApp equipeApp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var resultado = await EquipeManipulador.AdicionarAsync(equipeApp);
                    if (resultado > 0)
                    {
                        var resultadoModel = await EquipeManipulador.PegarAsync(resultado);
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
                                case "EquipeNome":
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
                    ModelState.AddModelError(string.Empty, "Problemas na Inserção!");
                }
            }
            var contentResult = new System.Web.Http.Results.ResponseMessageResult(Request.CreateResponse(HttpStatusCode.InternalServerError, ModelState));
            return contentResult;
        }

        // DELETE: api/EquipeApps/5
        [ResponseType(typeof(EquipeApp))]
        public async Task<IHttpActionResult> DeleteEquipeApp(long id)
        {
            throw new NotImplementedException();
            /*
                        EquipeApp equipeApp = await db.EquipeApps.FindAsync(id);
                        if (equipeApp == null)
                        {
                            return NotFound();
                        }

                        db.EquipeApps.Remove(equipeApp);
                        await db.SaveChangesAsync();

                        return Ok(equipeApp);*/
        }
        [HttpPut]
        [ResponseType(typeof(EquipeApp))]
        public async Task<IHttpActionResult> Put([FromUri] long id, [FromBody] EquipeApp equipeApp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    equipeApp.Id = id;

                    var resultado = await EquipeManipulador.AlterarAsync(equipeApp);
                    if (resultado == true)
                    {
                        var resultadoModel = await EquipeManipulador.PegarAsync(equipeApp.Id);
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
                                case "EquipeNome":
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
            var contentResult = new System.Web.Http.Results.ResponseMessageResult(Request.CreateResponse(HttpStatusCode.InternalServerError, ModelState));
            return contentResult;
        }
    }
}
