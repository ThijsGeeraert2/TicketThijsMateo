using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Extensions;
using TicketThijsMateo.Services.Interfaces;
using TicketThijsMateo.ViewModels;

namespace TicketThijsMateo.Controllers
{
    public class ShoppingCartController : Controller
    {

       
        public IActionResult Index()
        {
            ShoppingCartVM? cartList = HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart");

            if (cartList == null)
            {
                cartList = new ShoppingCartVM();
                cartList.Ticket = new List<TicketVM>();
                HttpContext.Session.SetObject("ShoppingCart", cartList);
            }

            return View(cartList);
        }

        public IActionResult Delete(int? wedstrijdId)
        {
            if (wedstrijdId == null)
            {
                return BadRequest("Invalid item id.");
            }

            ShoppingCartVM? cartList = HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart");

            if (cartList == null)
            {
                return NotFound("Shopping cart not found.");
            }

            var itemToRemove = cartList.Ticket.FirstOrDefault(t => t.WedstrijdId == wedstrijdId);

            if (itemToRemove != null)
            {
                cartList.Ticket.Remove(itemToRemove);
                HttpContext.Session.SetObject("ShoppingCart", cartList);
            }
            else
            {
                return NotFound("Item not found in the shopping cart.");
            }

            return RedirectToAction("Index");
        }
    }
}
