using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BangazonDelta.Data;
using Microsoft.EntityFrameworkCore;
using BangazonDelta.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["ProductTypeId"] = context.ProductType
                                       .OrderBy(l => l.Name)
                                       .AsEnumerable()
                                       .Select(li => new SelectListItem { 
                                           Text = li.Name,
                                           Value = li.ProductTypeId.ToString()
                                        });
            // ViewData["SubTypes"] = context.ProductSubType
            //                            .Where(c => c.ProductTypeId == 1)
            //                            .OrderBy(l => l.Name)
            //                            .AsEnumerable()
            //                            .Select(li => new SelectListItem { 
            //                                Text = $"{li.Name}",
            //                                Value = li.ProductSubTypeId.ToString()
            //                             });
            return View();
        }

        [HttpGet]
        public DbSet<ProductSubType> GetSubTypesForDropdown()
        {
            // List subtypes = new List<ProductSubType>{};
            var subTypes  = context.ProductSubType;//.ToListAsync();
            //this method is to create the dropdown for the user when they are creating a product and need to select a subtype
            //passing in the producttype id to the method
            // IQueryable<object> subtypes = 
            // from types in context.ProductType 
            // types = querying the database for all ProductTypes
            // join subtype in context.ProductSubType on id equals subtype.ProductSubTypeId
            //then, go to the ProductSubType table and get all of those too
            // where types.ProductTypeId == id 
            //then, get the subtypes that match the producttypeId we passed in
            // select subtype;
            //BINGO!!^

            // return View(subtypes);
            // ViewData["SubTypes"] = subtypes;
            return subTypes;
            //this is the variable that we assigned our query to, and what we were searching the database for
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.UserId = 1; //Temporary
                context.Add(product);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
