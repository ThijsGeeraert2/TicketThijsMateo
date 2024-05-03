using Microsoft.AspNetCore.Mvc;

namespace TicketThijsMateo.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
