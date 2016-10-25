using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BangazonDelta.Data;
using Microsoft.EntityFrameworkCore;

namespace BangazonTeamDelta.Controllers
{
    public class ProductsController : Controller
    {
        private BangazonDeltaContext context;

        public ProductsController(BangazonDeltaContext ctx)
        {
            context = ctx;
        }
        public async Task<IActionResult> Index()
        {
            return View(await context.Product.ToListAsync());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
