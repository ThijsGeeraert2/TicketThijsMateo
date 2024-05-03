using Microsoft.AspNetCore.Mvc;

namespace TicketThijsMateo.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
