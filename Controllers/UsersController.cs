using BangazonDelta.Models;
using Microsoft.AspNetCore.Mvc;
using BangazonDelta.Data;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> users = from user in context.User select user;
            
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }
    }
}