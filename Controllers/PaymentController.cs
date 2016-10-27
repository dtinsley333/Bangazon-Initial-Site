using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BangazonDelta.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using BangazonDelta.Models;

namespace BangazonTeamDelta.Controllers
{
    public class PaymentController : Controller
    {
        private BangazonDeltaContext context;

        public PaymentController(BangazonDeltaContext ctx)
        {
            context = ctx;
        }
        [HttpGet]
        public IActionResult AddPayment()
        
        {
            //by default, since this is the AddPayment method, C# will 
            //return the AddPayment View.  This view is empty until the cusotmer fills in data//
            return View();
        }

        [HttpPost]
//PaymentType is the model we are passing in during the POST, "payment "is just the variable name.
        public async Task<IActionResult> AddPayment(PaymentType payment)
        
        {
           PaymentType paymenttype = new PaymentType
           {
           AccountNumber= payment.AccountNumber,
           CVV= payment.CVV,
           Expiration= payment.Expiration,
           //just hard coded a customer ID until I have more info on this...//
           UserId= 1
           };

           //staging the database change...//
           context.PaymentType.Add(paymenttype);
           await context.SaveChangesAsync();
           ViewData["UserMessage"] = "Payment Type Succesfully Saved!";
           //*** NEED THE NAME OF THE ORDER CONTROLLER HERE!!!//
            // return RedirectToAction("ActionName", "OrderControllerName", "someObject");
            return View();

        }

        
    }
}



