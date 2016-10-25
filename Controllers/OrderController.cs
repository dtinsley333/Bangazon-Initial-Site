using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BangazonDelta.Data;

namespace BangazonTeamDelta.Controllers
{
    public class OrdersController : Controller
    {
        private BangazonDeltaContext context;
        public OrdersController(BangazonDeltaContext ctx)
        {
            context = ctx;
        }
        public async Task<IActionResult> Index([FromRoute]int? userId)
        {
            //if there is no id in the route then it will return 404
            if (userId == null)
            {
                return NotFound();
            }
            //check to see if the order attached to the customerId has any products associated with it
            var order = await context.Order
                .Include(order => order.UserId == userId);
            if (order == null)
            {
                return View();
                //return the empty cart view
            }
            //get all of the products with the user's id
            var OrderProduct = await context.Product
                .Include(prod => prod.userId == userId && Sold == false);

            if (product == null)
            {
                return View();
            }

            return View(product);
        }

    }
}
