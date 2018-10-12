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
        [HttpGet("corsi/{id}")]
        public IActionResult GetCorsoDocente([FromRoute] int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var corsoDocente = work.CorsiDocentiRepo.FindAll().Select(cd => cd.ToDTO()); // 26' PER QUESTA RIGA

            if (corsoDocente == null)
            {
                return NotFound();
            }

            return Ok(corsoDocente);
        }

        // PUT: api/Iscrizioni/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCorsoDocente([FromRoute] int id, [FromBody] CorsoDocente corsoDocente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != corsoDocente.IdDocente)
            {
                return BadRequest();
            }

            context.Entry(corsoDocente).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorsoDocenteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Iscrizioni
        [HttpPost]
        public async Task<IActionResult> PostCorsoDocente([FromBody] CorsoDocente corsoDocente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.CorsiDocenti.Add(corsoDocente);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CorsoDocenteExists(corsoDocente.IdDocente))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCorsoDocente", new { id = corsoDocente.IdDocente }, corsoDocente);
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