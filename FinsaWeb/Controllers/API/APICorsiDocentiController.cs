using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinsaWeb.Models;
using FinsaWeb.Models.EF;
using FinsaWeb.Models.CoreNocciolo.UoW;
using FinsaWeb.DTO.Extentions;
using FinsaWeb.DTO;
using System.Data;

namespace FinsaWeb.Controllers.API
{
    [Produces("application/json")]
    [Route("api/CorsiDocenti")]
    public class CorsiDocentiController : Controller
    {
        private FinsaContext context;

        public const string ROUTE_GET_COURSE = "ROUTE_GET_COURSE";
        private IDocenteUnitOfWork work;

        public CorsiDocentiController(IDocenteUnitOfWork work,FinsaContext context)
        {
            this.work = work;
            this.context = context;
        }

        // GET: api/Iscrizioni
        [HttpGet]
        public IActionResult GetCorsiDocenti()
        {
            List<CorsoDocente> corsi = context.CorsiDocenti.ToList();
            return Ok(corsi);
        }

        // GET: api/Iscrizioni/5
        // tutti i corsi di un dato docente // si mettono le entità quando crei il modello di controller api collegato ad EF
        [HttpGet("{id}", Name = "GetAPICorsiDocenti")]
        public IActionResult Get(int id) //GetCorsoDocente anche
        {
            CorsoDocente corso = context.CorsiDocenti.Find(id);
            if (corso == null)
            {
                return NotFound();
            }
            return Ok(corso);
            //if (id < 1)
            //{
            //    return BadRequest();
            //}

            //var corsoDocente = work.CorsiDocentiRepo.FindAll().Select(cd => cd.ToDTO()); // 26' PER QUESTA RIGA

            //if (corsoDocente == null)
            //{
            //    return NotFound();
            //}

            //return Ok(corsoDocente);
        }

        // PUT: api/Iscrizioni/5
        //[HttpPut("{id}")]
        //public IActionResult Update(int id, [FromBody]CorsoDocente value)
        //{
        //    //if (value == null)
        //    //{
        //    //    return BadRequest();
        //    //}
        //    //Docente doc = value.ToDocente();
        //    //try
        //    //{
        //    //    work.Begin();
        //    //    work.DocentiRepo.Update(doc);
        //    //    work.Save();
        //    //    work.End();

        //    //}
        //    //catch (DataException)
        //    //{
        //    //    return NotFound();
        //    //}
        //    //return NoContent();
        //}

        // POST: api/Iscrizioni
        [HttpPost]
        public IActionResult Post([FromBody]CorsoDocenteDTO value)
        {
            if (value == null)
                return BadRequest();
            CorsoDocente Docente = value.ToCorsoDocente();
            work.Begin();
            work.CorsiDocentiRepo.Add(Docente);
            work.Save();
            work.End();

            return CreatedAtRoute("ROUTE_GET_COURSE", new { id = Docente.IdEdizioneCorso }, Docente.ToDTO());

            //return CreatedAtAction("GetCorsoDocente", new { id = corsoDocente.IdDocente }, corsoDocente);
        }

        // DELETE: api/Iscrizioni/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCorsoDocente([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var corsoDocente = await context.CorsiDocenti.SingleOrDefaultAsync(m => m.IdDocente == id);
            if (corsoDocente == null)
            {
                return NotFound();
            }

            context.CorsiDocenti.Remove(corsoDocente);
            await context.SaveChangesAsync();

            return Ok(corsoDocente);
        }

        private bool CorsoDocenteExists(int id)
        {
            return context.CorsiDocenti.Any(e => e.IdDocente == id);
        }
    }
}