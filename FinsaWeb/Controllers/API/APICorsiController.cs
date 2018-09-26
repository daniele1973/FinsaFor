using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinsaWeb.Models;
using FinsaWeb.Models.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FinsaWeb.Controllers.API
{
    [Produces("application/json")]
    [Route("api/APICorsi")]
    public class APICorsiController : Controller
    {
        private FinsaContext context;

        public APICorsiController(FinsaContext context)
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
            Corso corso = context.Corsi.Single(c => c.IdCorso == id);
            return Ok(corso);
            //return corso;
            //return "hai chiamato: api/APICorsi/"+id;
        }

        // GET: api/APICorsi/PerNome/"Cors"
        [HttpGet("PerNome/{substring?}", Name = "GetByName")]
        public IActionResult GetByName(string substring="")
        {
            List<Corso> corsi = context.Corsi.Where(c => c.Titolo.Contains(substring)).ToList();
            return Ok(corsi);
            //return corso;
            //return "hai chiamato: api/APICorsi/"+id;
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
        public void Put(int id, [FromBody]Corso value)
        {
            Corso daAggiornare = context.Corsi.Single(c => c.IdCorso == id);
            daAggiornare.Titolo = value.Titolo;
            daAggiornare.PrezzoBase = value.PrezzoBase;
            daAggiornare.Difficolta = value.Difficolta;


            context.SaveChanges();
        }
       
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Corso daCancellare = context.Corsi.Single(c => c.IdCorso == id);
            context.Corsi.Remove(daCancellare);
            context.SaveChanges();
        }
    }
}
