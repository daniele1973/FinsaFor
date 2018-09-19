using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinsaWeb.Models.CoreNocciolo;
using Microsoft.AspNetCore.Mvc;
using FinsaWeb.Models;

namespace FinsaWeb.Controllers
{
    public class AllieviController : Controller
    {
        private IAllieviRepository repo;
        public AllieviController(IAllieviRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            repo.Add(new Allievo { Nome="Martino", Cognome="Gonzalo", CodiceFiscale="MTNGNZ78A45D969M",TipoAllievo="Mhhhhhh"});
            var lista = repo.FindAll();
            return View(lista);
        }
    }
}