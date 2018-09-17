using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult Index()
        {
            var result = repo.FindAll();
            return View(result);
        }
    }
}