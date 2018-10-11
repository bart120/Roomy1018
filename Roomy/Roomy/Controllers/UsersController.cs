using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
                try
                {
                    await db.Users.AddAsync(user);
                    await db.SaveChangesAsync();

                    TempData["Message"] = "Utilisateur enregistré.";
                    //ViewBag.Message = "Utilisateur enregistré.";

                    return RedirectToAction("index", "home");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("Mail", "Email existant.");
                }
            }
            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await db.Users.FirstOrDefaultAsync(x => x.Mail == model.Mail && x.Password == model.Password);
                if (user != null)
                {
                    HttpContext.Session.SetString("USER_BO", JsonConvert.SerializeObject(user));
                    
                    return RedirectToAction("index", "dashboard", new { area = "backoffice" });
                }else
                    ModelState.AddModelError("Mail", "Erreur login / mot de passe");
            }
            return View();
        }

    }
}