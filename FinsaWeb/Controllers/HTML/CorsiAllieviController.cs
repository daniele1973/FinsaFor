using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinsaWeb.Models;
using FinsaWeb.Models.CoreNocciolo;

namespace FinsaWeb.Controllers
{
    public class CorsiAllieviController : Controller
    {
        private ICorsiAllieviRepository reposit;
        public CorsiAllieviController(ICorsiAllieviRepository reposit)
        {
            this.reposit = reposit;
        }
        public IActionResult CorsiAllievi()
        {
            //reposit.Add(new CorsoAllievo { IdEdizioneCorso = 1, Voto = 8 });
            //reposit.Add(new CorsoAllievo { IdAllievo = 2, IdEdizioneCorso = "secondo", Voto = 6 });
            var listone = reposit.FindAll();
            return View(listone);
        }
    }
}

