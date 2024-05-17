using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Domains.Entities;
using TicketThijsMateo.Extensions;
using TicketThijsMateo.Repositories;
using TicketThijsMateo.Services;
using TicketThijsMateo.Services.Interfaces;
using TicketThijsMateo.ViewModels;

namespace TicketThijsMateo.Controllers
{
    public class WedstrijdController : Controller
    {
        private IService<Wedstrijden> wedstrijdService;

        private IService<Club> clubService;

        public IService<Soortplaatsen> soortplaatsService;

        private readonly IMapper _mapper;

        

        public WedstrijdController(IMapper mapper, IService<Wedstrijden> wService, IService<Club> cService, IService<Soortplaatsen> sService)
        {
            _mapper = mapper;
            wedstrijdService = wService;
            clubService = cService;
            soortplaatsService = sService;
     
        }

        public async Task<IActionResult> Index()  // add using System.Threading.Tasks;
        {
            var list = await wedstrijdService.GetAllAsync();
            List<WedstrijdVM> listVM = _mapper.Map<List<WedstrijdVM>>(list);
            return View(listVM);

        }

        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Wedstrijden? wedstrijd = await wedstrijdService.FindByIdAsync(Convert.ToInt32(id));

            var ticketCreate = new TicketCreateVM()
            {
                Soortplaatsen = new SelectList(await soortplaatsService.GetAllSoortPlaatsenByStadiumId(wedstrijd.Stadium.Id)
                  , "Id", "Naam"),
                wedstrijdId = wedstrijd.Id,
               
            };


            return View(ticketCreate);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TicketCreateVM ticketCreateVM)
        {

            if (ticketCreateVM != null)
            {
                TicketVM item = new TicketVM
                {
                    Betaald = false,
                    Voornaam = ticketCreateVM.Voornaam,
                    Familienaam = ticketCreateVM.Naam,
                    WedstrijdId = ticketCreateVM.wedstrijdId,
                    
                };

                ShoppingCartVM? shopping;

                if (HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart") != null)
                {
                    shopping = HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart");
                }
                else
                {
                    shopping = new ShoppingCartVM();
                    shopping.Ticket = new List<TicketVM>();
                }

                shopping?.Ticket?.Add(item);
                HttpContext.Session.SetObject("ShoppingCart", shopping);

            }
            return RedirectToAction("Index", "ShoppingCart");
           
        }
    }

    
}
