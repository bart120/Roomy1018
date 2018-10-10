using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Roomy.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            //ViewBag.Title = "Accueil";
            ViewData["Title"] = "Accueil";
            //ViewBag["Title"] = "Accueil";

            return View();
        }

        [Route("a-propos-de", Name = "apropos")]
        public IActionResult About()
        {
            return View();
        }
    }
}