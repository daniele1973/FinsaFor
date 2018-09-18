using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinsaWeb.Models;
//using FinsaWeb.Models.InMemory;
using FinsaWeb.Models.CoreNocciolo;

namespace FinsaForEver.Controllers
{
    public class Pippo { public string Testo1 { get; set; } }
    public class HomeController : Controller
    {
        

        private ICorsiRepository repo;
        public HomeController(ICorsiRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var p = new Pippo();
            p.Testo1 = "Concettualmente";
            
            return View(p);
        }
    }
}