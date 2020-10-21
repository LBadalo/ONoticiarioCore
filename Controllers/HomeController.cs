using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ONoticiarioCore.Data;
using ONoticiarioCore.Models;

namespace ONoticiarioCore.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }
        [AllowAnonymous]//apesar de existir restriçoes de acesso um utilizador anonimo consegue vizualizar noticias
        //GET: Noticias
        public IActionResult Index(string categoria, int? page)
        {
            var applicationDbContext = db.Noticias.Include(n => n.Utilizador);
            return View(applicationDbContext.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
