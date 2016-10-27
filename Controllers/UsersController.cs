using BangazonDelta.Models;
using Microsoft.AspNetCore.Mvc;
using BangazonDelta.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BangazonDelta.ViewModels;

namespace BangazonTeamDelta.Controllers
{
    public class UsersController : Controller
    {
        private BangazonDeltaContext context;

        public UsersController(BangazonDeltaContext ctx){
            context = ctx;
        }

        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.User.Add(user);
            try
            {
                context.SaveChanges();
                return RedirectToAction("Index", "Products");
            }
            catch (DbUpdateException)
            {
                    throw;
            }
        }
        public IActionResult Activate([FromBody]int UserId)
        {
          var user = context.User.SingleOrDefault(c => c.UserId == UserId);

          if (user == null)
          {
            return NotFound();
          }

          ActiveUser.Instance.User = user;


          string json = "{'result': 'true'}";
          return new ContentResult { Content = json, ContentType = "application/json" };
        }
    }
}