using BangazonDelta.Models;
using System.Linq;
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
            return CreatedAtRoute("GetUser", new { id = user.UserId }, user);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult Get([FromRoute] int id)
        {
            return Ok();
        }

        private bool CustomerExists(int id)
        {
            return context.User.Count(e => e.UserId == id) > 0;
        }

    }

}