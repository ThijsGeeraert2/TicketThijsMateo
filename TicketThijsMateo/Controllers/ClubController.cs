using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Services;
using TicketThijsMateo.Services.Interfaces;
using TicketThijsMateo.ViewModels;

namespace TicketThijsMateo.Controllers
{
    public class ClubController : Controller
    {
        private IService<Club> clubService;
        private IService<Soortplaats> soortplaatsService;


        private readonly IMapper _mapper;

        public ClubController(IMapper mapper, IService<Club> clubservice, IService<Soortplaats> soortpltsService)
        {
            _mapper = mapper;
            clubService = clubservice;
            soortplaatsService = soortpltsService;
        }

        public async Task<IActionResult> Index()  // add using System.Threading.Tasks;
        {
            var list = await clubService.GetAllAsync();
            List<ClubVM> listVM = _mapper.Map<List<ClubVM>>(list);
            return View(listVM);


        }

        public async Task<IActionResult> Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Club? club = await clubService.FindByIdAsync(Convert.ToInt32(id));

            var svm = new SubscriptionCreateVM()
            {
                Soortplaatsen = new SelectList(await soortplaatsService.GetAllSoortPlaatsenByStadiumId(club.Stadium.Id)
                  , "Id", "Naam"),
                ClubId = club.Id,
            };


            return View(svm);

        }
    }
}
