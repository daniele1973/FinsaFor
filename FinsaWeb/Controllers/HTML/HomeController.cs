using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinsaWeb.Models;
//using FinsaWeb.Models.InMemory;
using FinsaWeb.Models.CoreNocciolo;
using FinsaWeb.Views.Shared;

namespace FinsaForEver.Controllers
{
    public class HomeController : Controller
    {
        

        private ICorsiRepository repo;
        public HomeController(ICorsiRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var vb = new ViewBag();
            vb.TestoTitolo = "FINSA Course Manager_";
            
            return View(vb);
        }
    }
}