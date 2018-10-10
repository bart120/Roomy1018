using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roomy.Models;

namespace Roomy.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Create()
        {
            var user = new User { Lastname = "toto" };
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                //bdd...
            }
            return View(user);
        }
    }
}