using Autospace2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Autospace2.Controllers
{
    public class HomeController : Controller
    {
        public AppDbContext Context { get; private set; }

        public HomeController(AppDbContext context)
        {
            Context = context;
        }

        public IActionResult Shops()
        {
            var Model = Context.Shops.ToList();
            return View(Model);
        }

        public IActionResult Products(int id)
        {
            var Model = Context.Shops.Include(x => x.Products).FirstOrDefault(x => x.Id == id);
            return View(Model);
        }
    }
}
