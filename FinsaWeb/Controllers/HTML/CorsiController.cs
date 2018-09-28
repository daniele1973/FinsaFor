using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinsaWeb.Models;
using FinsaWeb.Models.CoreNocciolo;
using Microsoft.AspNetCore.Mvc;

namespace FinsaWeb.Controllers
{
    public class CorsiController : Controller
    {
        private ICorsiRepository repo;
        public CorsiController(ICorsiRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Corsi()
        {
            var result = repo.FindAll();
            return View(result);
        }

        public IActionResult Inserisci()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Inserisci(Corso corso)
        {
            if (ModelState.IsValid)
            {
                repo.Aggiungi(corso);
                return RedirectToAction("InserimentoCompleto"); 
            }

            return View(corso);
        }
        public IActionResult InserimentoCompleto()
        {
            var result = repo.FindAll();
           
            return View("corsi", result);
        }
    }
}