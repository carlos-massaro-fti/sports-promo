﻿using SportsPromo.App.Interfaces.Manipuladores;
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
    public class ApiChecagemController : ApiController
    {
        protected readonly IChecagemManipulador ChecagemManipulador;

        public ApiChecagemController(IChecagemManipulador checagemManipulador)
        {
            ChecagemManipulador = checagemManipulador;
        }

        // GET: api/EsporteApps
        [HttpGet]
        [ActionName("Index")]
        public async Task<HttpResponseMessage> Index([FromUri] int? page, [FromUri] string sort, [FromUri] int? direction)
        {
            var consulta = new PaginadoOrdenado<ChecagemApp>()
            {
                PaginaAtual = page ?? 1,
                ItensPorPagina = 6,
                OrdemNome = sort ?? "Id",
                OrdemDirecao = direction ?? 0
            };

            var resultado = await ChecagemManipulador.ListarAsync(consulta);

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
        [ResponseType(typeof(ChecagemApp))]
        public async Task<IHttpActionResult> Get(long id)
        {
            var resultado = await ChecagemManipulador.PegarAsync(id);

            if (resultado == null)
            {
                return NotFound();
            }

            return Ok(resultado);
        }

        // PUT: api/EsporteApps/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutChecagemApp(long id, ChecagemApp checagemApp)
        {
            throw new NotImplementedException();
            /*
                        if (!ModelState.IsValid)
                        {
                            return BadRequest(ModelState);
                        }

                        if (id != checagemApp.Id)
                        {
                            return BadRequest();
                        }

                        db.Entry(checagemApp).State = EntityState.Modified;

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
        [HttpPost]
        [ResponseType(typeof(ChecagemApp))]
        public async Task<IHttpActionResult> Post([FromBody] ChecagemApp checagemApp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var resultado = await ChecagemManipulador.AdicionarAsync(checagemApp);
                    if (resultado > 0)
                    {
                        var resultadoModel = await ChecagemManipulador.PegarAsync(resultado);
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
                                case "ChecagemRfid":
                                    localName = "Rfid";
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

        // DELETE: api/EsporteApps/5
        [ResponseType(typeof(ChecagemApp))]
        public async Task<IHttpActionResult> DeleteChecagemApp(long id)
        {
            throw new NotImplementedException();
            /*
                        EsporteApp checagemApp = await db.ChecagemApps.FindAsync(id);
                        if (checagemApp == null)
                        {
                            return NotFound();
                        }

                        db.ChecagemApps.Remove(checagemApp);
                        await db.SaveChangesAsync();

                        return Ok(checagemApp);*/
        }
        //[HttpPut]
        //[ResponseType(typeof(ChecagemApp))]
        //public async Task<IHttpActionResult> Put([FromBody] ChecagemApp checagemApp)
        //{
            
        //}
    }
}