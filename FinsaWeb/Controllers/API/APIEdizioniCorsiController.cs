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
    [Route("api/EdizioniCorsi")]
    public class APIEdizioniCorsiController : Controller
    {
        FinsaContext context;

        public APIEdizioniCorsiController(FinsaContext context)
        {
            this.context = context;
        }

        // GET: api/APIEdizioniCorsi
        [HttpGet]
        public IEnumerable<EdizioneCorso> Get()
        {
            return context.EdizioniCorsi.ToArray();
        }

        // GET: api/APIEdizioniCorsi/5
        [HttpGet("{id}", Name = "GetEdizioniCorso")]
        public ICollection<EdizioneCorso> Get(int id)
        {
            return context.EdizioniCorsi.Where(ec => ec.IdCorso == id).ToArray();
        }
        
        // POST: api/APIEdizioniCorsi
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
