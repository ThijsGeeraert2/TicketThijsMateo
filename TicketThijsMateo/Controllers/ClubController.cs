using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Domains.Entities;
using TicketThijsMateo.Extensions;
using TicketThijsMateo.Services;
using TicketThijsMateo.Services.Interfaces;
using TicketThijsMateo.ViewModels;

namespace TicketThijsMateo.Controllers
{
    public class ClubController : Controller
    {
        private IService<Club> clubService;
        private IService<Soortplaatsen> soortplaatsService;


        private readonly IMapper _mapper;

        public ClubController(IMapper mapper, IService<Club> clubservice, IService<Soortplaatsen> soortpltsService)
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
                ClubId = (int)id,
                ClubNaam = club.Naam,
            };


            return View(svm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubscriptionCreateVM svm)
        {

            if (svm != null)
            {
                DateTime currentDate = DateTime.Now;
                int currentYear = currentDate.Year;

                // Define the start and end dates of the season
                DateTime seasonStart = new DateTime(currentYear, 8, 1);
                DateTime seasonEnd = new DateTime(currentYear + 1, 5, 31);

                DateTime newSeasonStart;
                DateTime newSeasonEnd;

                if (currentDate.Month < 8)
                {
                    seasonStart = seasonStart.AddYears(-1);
                    seasonEnd = seasonEnd.AddYears(-1);
                }

                if (currentDate >= seasonStart && currentDate <= seasonEnd)
                {
                    newSeasonStart = seasonStart.AddYears(1);
                    newSeasonEnd = seasonEnd.AddYears(1);
                } else
                {
                    newSeasonStart = seasonStart;
                    newSeasonEnd = seasonEnd;
                }

                SubscriptionVM item = new SubscriptionVM
                {
                    Betaald = false,
                    Voornaam = svm.Voornaam,
                    Familienaam = svm.Naam,
                    ClubId = svm.ClubId,
                    SoortplaatsNr = svm.Soortplaatsnr,
                    StartDatum = newSeasonStart,
                    EindDatum = newSeasonEnd,

                };

                ShoppingCartVM? shopping;

                if (HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart") != null)
                {
                    shopping = HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart");
                }
                else
                {
                    shopping = new ShoppingCartVM();
                    shopping.Subscription = new List<SubscriptionVM>();
                }

                if(shopping.Subscription == null)
                {
                    shopping.Subscription = new List<SubscriptionVM>();
                }

                shopping?.Subscription?.Add(item);
                HttpContext.Session.SetObject("ShoppingCart", shopping);

            }
            return RedirectToAction("Index", "ShoppingCart");

        }
    }
}
