using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FinsaWeb.Controllers
{
    public class DocentiController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}