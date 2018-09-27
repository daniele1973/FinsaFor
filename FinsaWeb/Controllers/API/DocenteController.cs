using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinsaWeb.Models.CoreNocciolo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinsaWeb.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Docente")]
    public class DocenteController : Controller
    {
        private IDocenteUnitOfWork work;
        public DocenteController(IDocenteUnitOfWork work)
        {
            this.work = work;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var docenti = work.Docenti.FindAll();
            return null;
        }
    }
}