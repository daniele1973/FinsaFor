using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinsaWeb.Models;
using FinsaWeb.Models.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinsaWeb.Controllers.API
{
    [Produces("application/json")]
    [Route("api/APICorsi")]
    public class APICorsiAllieviController : Controller
    {
        private FinsaContext context;

        public APICorsiAllieviController(FinsaContext context)
        {
            this.context = context;
        }

        // GET: api/APICorsi
        [HttpGet]
        public IActionResult Get()
        {
            List<Corso> corsi = context.Corsi.ToList();
            return Ok(corsi);
        }

        // GET: api/APICorsi/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            Corso corso = context.Corsi.Find(id);
            // Corso corso = context.Corsi.Single(c => c.IdCorso == id);
            if (corso == null)
            {
                return NotFound();
            }
            return Ok(corso);
        }

        // GET: api/APICorsi/PerNome/"Cors"
        [HttpGet("PerNome/{substring?}", Name = "GetByName")]
        public IActionResult GetByName(string substring = "")
        {
            List<Corso> corsi = context.Corsi.Where(c => c.Titolo.Contains(substring)).ToList();
            return Ok(corsi);
        }

        // POST: api/APICorsi
        [HttpPost]
        public void Post([FromBody]Corso value)
        {
            Corso daInserire = new Corso()
            {
                Titolo = value.Titolo,
                PrezzoBase = value.PrezzoBase,
                Difficolta = value.Difficolta
            };

            context.Corsi.Add(daInserire);
            context.SaveChanges();
        }

        // PUT: api/APICorsi/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Corso value)
        {
            //Corso daAggiornare = context.Corsi.Find(id);
            //if(daAggiornare == null)
            //{
            //    return NotFound();
            //}
            //daAggiornare.Titolo = value.Titolo;
            //daAggiornare.PrezzoBase = value.PrezzoBase;
            //daAggiornare.Difficolta = value.Difficolta;
            try
            {
                value.IdCorso = id;
                context.Corsi.Update(value);
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return NotFound();
            }


            return Ok(value);
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Corso daCancellare = context.Corsi.Single(c => c.IdCorso == id);
            context.Corsi.Remove(daCancellare);
            context.SaveChanges();
        }

        // _dg_ PATCH: api/APICorsi/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<Corso> jsonPatchDocument)
        {
            if (jsonPatchDocument == null)
            {
                return BadRequest();
            }

            Corso daPatchareFromStore = context.Corsi.FirstOrDefault(c => c.IdCorso == id);

            if (daPatchareFromStore == null)
            {
                return NotFound();
            }

            //Corso daPatchareNew = new Corso
            //{
            //    Titolo = daPatchareFromStore.Titolo,
            //    PrezzoBase = daPatchareFromStore.PrezzoBase,
            //    Difficolta = daPatchareFromStore.Difficolta
            //};

            jsonPatchDocument.ApplyTo(daPatchareFromStore, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TryValidateModel(daPatchareFromStore);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //daPatchareFromStore.Titolo = daPatchareNew.Titolo;
            //daPatchareFromStore.Difficolta = daPatchareNew.Difficolta;
            //daPatchareFromStore.PrezzoBase = daPatchareNew.PrezzoBase;

            context.SaveChanges();

            return NoContent();
        }
    }
}