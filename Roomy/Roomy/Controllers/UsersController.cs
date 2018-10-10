using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Roomy.Data;
using Roomy.Models;

namespace Roomy.Controllers
{
    public class UsersController : Controller
    {
        private RoomyDbContext db;

        public UsersController(RoomyDbContext db)
        {
            this.db = db;
        }

        public IActionResult Create()
        {
            //var user = new User { Lastname = "toto" }; 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();

                TempData["Message"] = "Utilisateur enregistré.";
                //ViewBag.Message = "Utilisateur enregistré.";

                return RedirectToAction("index", "home");
            }
            return View(user);
        }
    }
}