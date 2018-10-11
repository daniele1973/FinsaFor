using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinsaWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinsaWeb.Controllers
{
    public class CorsiInserisciController : Controller
    {
        public IActionResult CorsiInserisci()
        {
            Corso corso = new Corso();
            return View(corso);
        }
    }
}