using BangazonDelta.Models;
using Microsoft.AspNetCore.Mvc;
using BangazonDelta.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace BangazonTeamDelta.Controllers
{
    public class UserController : Controller
    {
        private BangazonDeltaContext context;

        public UserController(BangazonDeltaContext ctx){
            context = ctx;
        }

        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
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
                if (CustomerExists(user.UserId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }
    }
}