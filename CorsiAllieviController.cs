using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinsaWeb.Models;

namespace FinsaWeb.Controllers
{
    public class CorsiAllieviController : Controller
    {
        private ICorsiAllieviRepository reposit;
        public CorsiAllieviController(ICorsiAllieviRepository reposit)
        {
            this.reposit = reposit;
        }
        public IActionResult Index()
        {
            reposit.Add(new CorsiAllievi { IDAllievo = "Alessandro", IDEdizioneCorso = "prima", Voto = "8" });
            reposit.Add(new CorsiAllievi { IDAllievo = "Daniele", IDEdizioneCorso = "secondo", Voto = "6" });
            var listone = reposit.FindAll();
            return View(listone);
        }
    }
}