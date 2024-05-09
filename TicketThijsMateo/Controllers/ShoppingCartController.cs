using Microsoft.AspNetCore.Mvc;
using TicketThijsMateo.Extensions;
using TicketThijsMateo.ViewModels;

namespace TicketThijsMateo.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            ShoppingCartVM? cartList = HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart");

            return View(cartList);
        }

    }
}
