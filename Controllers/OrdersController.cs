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
            // This is an async function, but "await" is never used
            // Trying to figure out which part of this call is await-able
            // and where to do it in the LINQ call
            // Or does this even need to BE async??? We may never know

            var productsOnOrder =
            from ord in context.Order
            join uid in context.User on ord.UserId equals uid.UserId
            join op in context.OrderProduct on ord.OrderId equals op.OrderId
            join prod in context.Product on op.ProductId equals prod.ProductId
            where ord.UserId == 3
            && ord.PaymentTypeId == null
            && prod.Sold == false
            select prod;

            UserOrderViewModel uorder = new UserOrderViewModel();
            uorder.Product = productsOnOrder;

            if (productsOnOrder == null)
            {
                // This is where we could build a new ViewModel for when the user's cart is empty
                // All of the logic for an empty order view will be within this IF block
                // In pseudo-code,, it might be something like...

                // EmptyOrderViewModel emptyOrder = new EmptyOrderViewModel();
                // emptyOrder.message = "The user's cart is empty!";
                // return View(emptyOrder);

                return View();
            }
            return View(uorder);
        }

    }
}
