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

        public async Task<IActionResult> ProductTypes()
        {
            return View(await context.ProductType.ToListAsync());
        }

        public async Task<IActionResult> ProductTypeDetail([FromRoute]int id)
        {
            // If no id was in the route, return 404
            if (id == null)
            {
                return NotFound();
            }

            var productType = await context.ProductType
                    .Include(s => s.Products)
                    .SingleOrDefaultAsync(m => m.ProductTypeId == id);

            // If product not found, return 404
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        public async Task<IActionResult> Detail([FromRoute]int? id)
        {
            // If no id was in the route, return 404
            if (id == null)
            {
                return NotFound();
            }

            var product = await context.Product
                    .Include(s => s.User)
                    .SingleOrDefaultAsync(m => m.ProductId == id);

            // If product not found, return 404
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Create()
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
