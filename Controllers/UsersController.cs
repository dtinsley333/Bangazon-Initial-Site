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
            }
            catch (DbUpdateException)
            {
                    throw;
            }
            return Ok();
        }
    }
}