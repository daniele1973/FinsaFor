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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/APICorsi/5
        [HttpGet("{id}", Name = "Get")]
        public Corso Get(int id)
        {
            Corso corso = context.Corsi.First(c => c.IdCorso == id);
            return corso;

            //return "hai chiamato: api/APICorsi/"+id;
        }
        
        // POST: api/APICorsi
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/APICorsi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
