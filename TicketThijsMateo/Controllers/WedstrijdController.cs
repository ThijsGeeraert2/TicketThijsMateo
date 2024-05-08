using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Repositories;
using TicketThijsMateo.Services;
using TicketThijsMateo.Services.Interfaces;
using TicketThijsMateo.ViewModels;

namespace TicketThijsMateo.Controllers
{
    public class WedstrijdController : Controller
    {
        private IService<Wedstrijd> wedstrijdService;

        private IService<Club> clubService;

        public IService<Soortplaats> soortplaatsService;

        private readonly IMapper _mapper;

        

        public WedstrijdController(IMapper mapper, IService<Wedstrijd> wService, IService<Club> cService, IService<Soortplaats> sService)
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

            Wedstrijd? wedstrijd = await wedstrijdService.FindByIdAsync(Convert.ToInt32(id));

            var beerCreate = new TicketCreateVM()
            {
                Soortplaatsen = new SelectList(await soortplaatsService.GetAllSoortPlaatsenByStadiumId(wedstrijd.StadiumId)
                  , "Id", "Naam"),
               
            };


            return View(beerCreate);

        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(//VM)
        {
            //maak sessie objectb aan
        }*/

    }
}
