using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TicketThijsMateo.Domains.Entities;
using TicketThijsMateo.Services.Interfaces;

namespace TicketThijsMateo.Controllers
{
    

    public class GeschiedenisController : Controller
    {
        private IService<Ticket> _ticketService;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public GeschiedenisController(IService<Ticket> ticketService, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _ticketService = ticketService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            var list = await _ticketService.GetTicketsByUserID(currentUser.Id);
            List<Ticket> tickets = new List<Ticket>();
            return View(tickets);
        }
    }
}
