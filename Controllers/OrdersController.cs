using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BangazonDelta.Data;

namespace BangazonTeamDelta.Controllers
{
    public class OrderController : Controller
    {
        private BangazonDeltaContext context;
        public OrderController(BangazonDeltaContext ctx)
        {
            context = ctx;
        }
         public async Task<IActionResult> purchase([FromRoute]int? id)
        {
            return View();
        }
    }
}     