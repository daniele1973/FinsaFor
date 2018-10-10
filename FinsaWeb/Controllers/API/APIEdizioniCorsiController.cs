using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinsaWeb.DTO;
using FinsaWeb.DTO.Extentions;
using FinsaWeb.Models;
using FinsaWeb.Models.CoreNocciolo.UoW;
using FinsaWeb.Models.EF;
using FinsaWeb.Models.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinsaWeb.Controllers.API
{
    [Produces("application/json")]
    [Route("api/EdizioniCorsi")]
    public class APIEdizioniCorsiController : Controller
    {
        IEdizioniCorsiUnitOfWork work;

        public APIEdizioniCorsiController(IEdizioniCorsiUnitOfWork work)
        {
            this.work = work;
        }

        // GET: api/EdizioniCorsi
        [HttpGet]
        public IActionResult Get()
        {
            var result = work.EdizioniCorsiRepo.FindAll().Select( ec => ec.ToDTO() );
            return Ok(result);
        }

        //GET: api/EdizioniCorsi/DelCorso/5
        [HttpGet("DelCorso/{idCorso}")]
        public IActionResult GetEditionOfCourse(int idCorso)
        {
            var result = work.EdizioniCorsiRepo.FindAll().Where(ec => ec.IdCorso == idCorso);
            return Ok(result);
        }

        // GET: api/EdizioniCorsi/5
        [HttpGet("{idEdizioneCorso}", Name = "GetEdizioneCorso")]
        public IActionResult Get(int idEdizioneCorso)
        {
            var result = work.EdizioniCorsiRepo.Find(idEdizioneCorso).ToDTO();
            return Ok(result);
        }
        
        // POST: api/EdizioniCorsi
        [HttpPost]
        public IActionResult Post([FromBody]EdizioneCorsoDTO edizioneCorsoDTO)
        {
            if(edizioneCorsoDTO==null) { return BadRequest(); }

            EdizioneCorso edizioneCorso = edizioneCorsoDTO.ToEdizioneCorso();

            //work.Begin();
            //work.EdizioniCorsiRepo.Add(edizioneCorso);
            //work.Save();
            //work.End();

            try
            {
                work.Add(edizioneCorso);
            }
            catch (BusinessLogicException e)
            {
                return BadRequest(e);
            }


        //N.B.: il tipo anonimo che viene passato a CreatedAtRoute(,,) come secondo parametro "routeValues:"
        //      deve avere un campo che si chiama COME IL PARAMETRO della Route passatagli come primo argomento.
        //          (In questo caso come routeName: gli passiamo "GetEdizioneCorso", e quindi il campo del tipo anonimo
        //           che gli passiamo come routeValues: deve chiamarsi idEdizioneCorso)
        //      
        //      In caso contrario, SEBBENE METTENDO UN BREAKPOINT SU return risposta; il valore di "risposta" sembri essere corretto,
        //      Postman riceve uno status 500 (Internal Server Error) e la pagina di errore html inizia con le seguenti tre righe:
        //      « An unhandled exception occurred while processing the request.
        //        InvalidOperationException: No route matches the supplied values.
        //        Microsoft.AspNetCore.Mvc.CreatedAtRouteResult.OnFormatting(ActionContext context) »
            var risposta = CreatedAtRoute(routeName: "GetEdizioneCorso",
                                          routeValues: new { idEdizioneCorso = edizioneCorso.IdEdizioneCorso },
                                          value: edizioneCorso.ToDTO());
            return risposta;
        }
        
        // PUT: api/APIEdizioniCorsi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/APIApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
