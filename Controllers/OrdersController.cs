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
                return View();
            }
            return View(uorder);
        }

    }
}
