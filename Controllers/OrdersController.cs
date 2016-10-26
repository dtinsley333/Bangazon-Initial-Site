using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using BangazonDelta.Data;
using BangazonDelta.Models;
using BangazonDelta.ViewModels;


namespace BangazonTeamDelta.Controllers
{
    public class OrdersController : Controller
    {
        private BangazonDeltaContext context;
        public OrdersController(BangazonDeltaContext ctx)
        {
            context = ctx;
        }
        public async Task<IActionResult> Index([FromRoute]int userId)
        {
            //if there is no id in the route then it will return 404
            if (userId == null)
            {
                return NotFound();
            }


            // var userOrder = await context.Order
            //     .Include(order => order.User)
            //     .SingleOrDefaultAsync(order => order.UserId == userId && order.PaymentTypeId == null);
                    //this logic is to get the orderId. This happens by getting all of the orders, then checking for the order that has the userId on it and then making sure the order has not been completed by checking if PaymentTypeId == null

            // var productsOnOrder = await context.OrderProduct
            //     .Include(o => o.Order)
            //     .Where(a => a.OrderId == userOrder.OrderId);
                    //this logic is checking for the products that are associated with the orderId by getting all of the OrderProduct objects and checking for the OrderId and grabing the products 

            UserOrderViewModel model = new UserOrderViewModel(context);

            var productsOnOrder =
            from ord in context.Order
            join uid in context.User on ord.UserId equals uid.UserId
            join op in context.OrderProduct on ord.OrderId equals op.OrderId
            join prod in context.Product on op.ProductId equals prod.ProductId
            where op.ProductId == prod.ProductId 
            select prod;


            if (productsOnOrder == null)
            {
                return View();
            }

            return View(productsOnOrder);
        }

    }
}
