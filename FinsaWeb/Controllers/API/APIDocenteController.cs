using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinsaWeb.DTO;
using FinsaWeb.DTO.Extentions;
using FinsaWeb.Models;
using FinsaWeb.Models.CoreNocciolo;
using FinsaWeb.Models.CoreNocciolo.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinsaWeb.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Docenti")]
    public class APIDocenteController : Controller
    {
        public const string ROUTE_GET_COURSE = "ROUTE_GET_COURSE";
        private IDocenteUnitOfWork work;
        public APIDocenteController(IDocenteUnitOfWork work)
        {
            this.work = work;
        }

        [HttpGet("{id}", Name = ROUTE_GET_COURSE)]
        public IActionResult Get(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            Docente doc = work.DocentiRepo.Find(id);
            if (doc == null)
            {
                return NotFound();
            }
            return Ok(doc.ToDTO());
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var docenti = work.DocentiRepo.FindAll().Select(d => d.ToDTO());

            //docenti.Where(doc => doc.Nome == "pippo");
            //List<DocenteDTO> docs = new List<DocenteDTO>();
            //for(int i = 0; i < docenti.Count(); i++)
            //{
            //    docs.Add(docenti[i].ToDTO());
            //}
            return Ok(docenti);
        }


        [HttpPost]
        public IActionResult Crea([FromBody] DocenteDTO docDTO)
        {
            if(docDTO == null)
            {
                return BadRequest();
            }
            Docente doc = docDTO.ToDocente();
            work.Begin();
            work.DocentiRepo.Add(doc);
            work.Save();
            work.End();
            return CreatedAtRoute(ROUTE_GET_COURSE, new { id = doc.IdDocente }, doc.ToDTO()); //risp al client
        }

        [HttpPut]
        public IActionResult Update([FromBody] DocenteDTO docDTO)
        {
            if (docDTO == null)
            {
                return BadRequest();
            }
            Docente doc = docDTO.ToDocente();
            try
            {
               work.Begin();
               work.DocentiRepo.Update(doc);
               work.Save();
               work.End();

            }
            catch (DataException)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}/delete")]
        public IActionResult Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            try
            {
                work.Begin();
                work.DocentiRepo.Delete(id);
                work.Save();
                work.End();

            }
            catch (DataException)
            {
                return NotFound();
            }
            //var studente = work.AllieviRepo.FindAll().Select(d => d.ToDTO());
            //return Ok(studente);
            return Ok();
        }
    }
}