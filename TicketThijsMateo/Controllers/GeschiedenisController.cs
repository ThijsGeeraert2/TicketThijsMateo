using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TicketThijsMateo.Domains.Entities;
using TicketThijsMateo.Services.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using TicketThijsMateo.ViewModels;
using TicketThijsMateo.Services;

namespace TicketThijsMateo.Controllers
{
    public class GeschiedenisController : Controller
    {
        private readonly IService<Ticket> _ticketService;
        private readonly IService<Abonnementen> _abonnementService;
        private readonly IService<Club> _clubService;
        private readonly IService<Zitplaatsen> _zitplaatsenService;
        private readonly IService<Wedstrijden> _wedstrijdenService;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public GeschiedenisController(
            IService<Ticket> ticketService,
            IService<Abonnementen> abonnementService,
            IService<Club> clubService,
            IService<Zitplaatsen> zitplaatsenService,
            IService<Wedstrijden> wedstrijdenService,
            IMapper mapper,
            UserManager<IdentityUser> userManager)
        {
            _ticketService = ticketService;
            _abonnementService = abonnementService;
            _clubService = clubService;
            _zitplaatsenService = zitplaatsenService;
            _wedstrijdenService = wedstrijdenService;

            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                var tickets = await _ticketService.GetTicketsByUserID(currentUser.Id);
                var ticketViewModels = new List<TicketGeschiedenisVM>();

                var abonnementen = await _abonnementService.GetTicketsByUserID(currentUser.Id);

                foreach (var ticket in tickets)
                {
                    //var zitplaats = await _zitplaatsenService.FindByIdAsync((int)ticket.ZitplaatsId);
                    Wedstrijden wedstrijd = await _wedstrijdenService.FindByIdAsync(ticket.WedstrijdId);
                    Club thuisPloeg = await _clubService.FindByIdAsync(wedstrijd.ThuisPloegId);
                    Club uitPloeg = await _clubService.FindByIdAsync(wedstrijd.UitPloegId);

                    TicketGeschiedenisVM ticketGeschiedenisVM = new TicketGeschiedenisVM
                    {
                        Ticket = ticket,
                        ThuisPloegNaam = thuisPloeg.Naam,
                        UitPloegNaam = uitPloeg.Naam,
                        WedstrijdDatum = wedstrijd.Datum
                    };
                    

                    ticketViewModels.Add(ticketGeschiedenisVM);
                }

                var viewModel = new GeschiedenisViewModel
                {
                    Tickets = ticketViewModels,
                    Abonnementen = abonnementen.ToList()
                };

                return View(viewModel);
            }
            return View();
        }
    }
}
