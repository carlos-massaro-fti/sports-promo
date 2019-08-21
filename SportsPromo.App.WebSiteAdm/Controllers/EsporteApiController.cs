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

namespace SportsPromo.App.WebSiteAdm.Controllers
{
    public class ApiEsporteController : ApiController
    {
        protected readonly IEsporteManipulador EsporteManipulador;

        public ApiEsporteController(IEsporteManipulador esporteManipulador)
        {
            EsporteManipulador = esporteManipulador;
        }

        // GET: api/EsporteApps
       [HttpGet]
       [ActionName("Index")]
        public async Task<HttpResponseMessage> Index([FromUri] int? page, [FromUri] string sort, [FromUri] int? direction)
        {
            var consulta = new PaginadoOrdenado<EsporteApp>()
            {
                PaginaAtual = page ?? 1,
                ItensPorPagina = 6,
                OrdemNome = sort ?? "Id",
                OrdemDirecao = direction ?? 0
            };

            var resultado = await EsporteManipulador.ListarAsync(consulta);

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
        [ResponseType(typeof(EsporteApp))]
        public async Task<IHttpActionResult> GetEsporteApp(long id)
        {
            throw new NotImplementedException();
           /* EsporteApp esporteApp = await db.EsporteApps.FindAsync(id);
            if (esporteApp == null)
            {
                return NotFound();
            }

            return Ok(esporteApp);*/
        }

        // PUT: api/EsporteApps/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEsporteApp(long id, EsporteApp esporteApp)
        {
            throw new NotImplementedException();
/*
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != esporteApp.Id)
            {
                return BadRequest();
            }

            db.Entry(esporteApp).State = EntityState.Modified;

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

        // POST: api/EsporteApps
        [ResponseType(typeof(EsporteApp))]
        public async Task<IHttpActionResult> PostEsporteApp(EsporteApp esporteApp)
        {
            throw new NotImplementedException();
/*
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EsporteApps.Add(esporteApp);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = esporteApp.Id }, esporteApp);
     */   }

        // DELETE: api/EsporteApps/5
        [ResponseType(typeof(EsporteApp))]
        public async Task<IHttpActionResult> DeleteEsporteApp(long id)
        {
            throw new NotImplementedException();
/*
            EsporteApp esporteApp = await db.EsporteApps.FindAsync(id);
            if (esporteApp == null)
            {
                return NotFound();
            }

            db.EsporteApps.Remove(esporteApp);
            await db.SaveChangesAsync();

            return Ok(esporteApp);*/
        }
    }
}