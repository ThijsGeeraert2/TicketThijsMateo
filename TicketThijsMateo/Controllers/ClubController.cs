using Microsoft.AspNetCore.Mvc;

namespace TicketThijsMateo.Controllers
{
    public class ClubController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
