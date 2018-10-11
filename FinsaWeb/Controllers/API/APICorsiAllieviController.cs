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
using FinsaWeb.Models.Exceptions;
using FinsaWeb.DTO;
using FinsaWeb.DTO.Extentions;
using FinsaWeb.Models.CoreNocciolo.UoW;

namespace FinsaWeb.Controllers.API
{
    [Produces("application/json")]
    [Route("api/CorsiAllievi")]
    public class APICorsiAllieviController : Controller
    {
        private FinsaContext context;
        private IAllieviUnitOfWork work;

        public APICorsiAllieviController(FinsaContext context , IAllieviUnitOfWork work)
        {
            this.context = context;
            this.work = work;
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
        public IActionResult Post([FromBody]CorsoAllievoDTO value)
        {
            if (value == null)
                return BadRequest();
            CorsoAllievo corso = value.ToCorsoAllievo();
            work.Begin();
            work.CorsiAllieviRepo.Add(corso);
            work.Save();
            work.End();

            return CreatedAtRoute("ROUTE_GET_ALLIEVI", new { id = corso.IdEdizioneCorso }, corso.ToDTO());



            /*CorsoAllievo daInserire = new CorsoAllievo()
            {
                IdAllievo = value.IdAllievo,
                IdEdizioneCorso = value.IdEdizioneCorso,
                Voto = value.Voto
            };
            try
            {               
                context.CorsiAllievi.Add(daInserire);
                context.SaveChanges();
            }
            catch(Exception e)
            {
                return BadRequest(new BusinessLogicException("Errore Inserimento", e));
            }
            return Ok(daInserire);*/
        }


        /*[HttpPost]
        public IActionResult Crea([FromBody] AllievoDTO studDTO)
        {
            if (studDTO == null)
            {
                return BadRequest();
            }
            Allievo stud = studDTO.ToAllievo();
            work.Begin();
            work.AllieviRepo.Add(stud);
            work.Save();
            work.End();
            return CreatedAtRoute(ROUTE_GET_ALLIEVI, new { id = stud.IdStudente }, stud.ToDTO()); //risp al client
        }
        */





        // PUT: api/APICorsiAllievi/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CorsoAllievo value)
        {
            try
            {
                CorsoAllievo daAggiornare = context.CorsiAllievi.Find(id);
                if (daAggiornare == null)
                {
                    //return NotFound();
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
                return NotFound(new BusinessLogicException("Elemento non trovato", e));
            }
            catch (Exception e)
            {
                return BadRequest(new BusinessLogicException("Errore ", e));
            }
            return Ok(value);
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Corso daCancellare = context.Corsi.Single(c => c.IdCorso == id);
            try
            {
                CorsoAllievo daCancellare = context.CorsiAllievi.Find(id);
                context.CorsiAllievi.Remove(daCancellare);
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return NotFound(new BusinessLogicException("Elemento non trovato", e));
            }
            catch (Exception e)
            {
                return BadRequest(new BusinessLogicException("Errore ", e));
            }
            return Ok();
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