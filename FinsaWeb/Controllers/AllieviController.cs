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
            //repo.Add(new Allievo { Nome="Martino", Cognome="Gonzalo", CodiceFiscale="MTNGNZ78A45D969M",TipoStudente="Mhhhhhh"});
            //var lista = repo.FindAll();
            //return View(lista);
            return View();
        }

        public IActionResult Inserisci()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Inserisci(Allievo allievo)
        {
            if (ModelState.IsValid)
            {
                repo.Add(allievo);
                return RedirectToAction("Inserisci","Allievi/Index");
            }

            return View(allievo);
        }
        public IActionResult Visualizza()
        {
            var lista = repo.FindAll();
            return View(lista);
        }
    }
}