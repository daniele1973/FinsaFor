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
    [Route("api/CorsiAllievi")]
    public class APICorsiAllieviController : Controller
    {
        private FinsaContext context;

        public APICorsiAllieviController(FinsaContext context)
        {
            this.context = context;
        }

        // GET: api/APICorsiAllievi
        [HttpGet]
        public IActionResult Get()
        {
            List<CorsoAllievo> corsi = context.CorsiAllievi.ToList();
            return Ok(corsi);
        }

        // GET: api/APICorsiAllievi/5
        [HttpGet("{id}", Name = "GetAPICorsiAllievi")]
        public IActionResult Get(int id)
        {
            CorsoAllievo corso = context.CorsiAllievi.Find(id);
            // CorsoAllievo corso = context.Corsi.Single(c => c.IdCorso == id);
            if (corso == null)
            {
                return NotFound();
            }
            return Ok(corso);
        }

        // GET: api/APICorsiAllievi/PerNome/"Cors"
        /*[HttpGet("PerNome/{substring?}", Name = "GetByName")]
        public IActionResult GetByName(string substring = "")
        {
            List<CorsoAllievo> corsi = context.CorsiAllievi.Where(c => c.Titolo.Contains(substring)).ToList();
            return Ok(corsi);
        }*/

        // POST: api/APICorsiAllievi
        [HttpPost]
        public void Post([FromBody]CorsoAllievo value)
        {
            CorsoAllievo daInserire = new CorsoAllievo()
            {
                IdAllievo = value.IdAllievo,
                IdEdizioneCorso = value.IdEdizioneCorso,
                Voto = value.Voto
            };
            context.CorsiAllievi.Add(daInserire);
            context.SaveChanges();
        }

        // PUT: api/APICorsiAllievi/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CorsoAllievo value)
        {
            try
            {
                CorsoAllievo daAggiornare = context.CorsiAllievi.Find(id);
                if (daAggiornare == null)
                {
                    return NotFound();
                }
                daAggiornare.IdAllievo = value.IdAllievo;
                daAggiornare.IdEdizioneCorso = value.IdEdizioneCorso;
                daAggiornare.Voto = value.Voto;

                //value.IdCorso = id;
                //context.Corsi.Update(value);
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
            // Corso daCancellare = context.Corsi.Single(c => c.IdCorso == id);
            CorsoAllievo daCancellare = context.CorsiAllievi.Find(id);
            context.CorsiAllievi.Remove(daCancellare);
            context.SaveChanges();
        }

        // _dg_ PATCH: api/APICorsiAllievi/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<CorsoAllievo> jsonPatchDocument)
        {
            if (jsonPatchDocument == null)
            {
                return BadRequest();
            }

            //CorsoAllievo daPatchareFromStore = context.CorsiAllievi.FirstOrDefault(c => c.IdCorso == id);
            CorsoAllievo daPatchareFromStore = context.CorsiAllievi.Find(id);

            if (daPatchareFromStore == null)
            {
                return NotFound();
            }
            //Corso daPatchareNew = new Corso
            //{
            //    IdAllievo = daPatchareFromStore.IdAllievo,
            //    IdEdizioneCorso = daPatchareFromStore.IdEdizioneCorso,
            //    Voto = daPatchareFromStore.Voto
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
            //daPatchareFromStore.IdAllievo = daPatchareNew.IdAllievo;
            //daPatchareFromStore.IdEdizioneCorso = daPatchareNew.IdEdizioneCorso;
            //daPatchareFromStore.Voto = daPatchareNew.Voto;

            context.SaveChanges();
            return NoContent();
        }
    }
}