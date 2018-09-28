using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinsaWeb.Models;
using FinsaWeb.Models.CoreNocciolo;


namespace FinsaWeb.Controllers
{
    public class EdizioniCorsiController : Controller
    {
        private IEdizioniCorsiRepository repository;

        public EdizioniCorsiController(IEdizioniCorsiRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Visualizza()
        {
            var result = repository.FindAll();
            return View(result);
        }

        public IActionResult Inserisci()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Inserisci(EdizioneCorso edizioneCorso)
        {
            if (ModelState.IsValid)
            {
                repository.Aggiungi(edizioneCorso);
                return RedirectToAction("InserimentoCompleto"); //vedi metodo InserimentoCompleto qui sotto
            }
            return View(edizioneCorso);
        }

        public IActionResult InserimentoCompleto()
        {
            var result = repository.FindAll();
            return View("EdizioniCorsi", result);
        }
    }
}