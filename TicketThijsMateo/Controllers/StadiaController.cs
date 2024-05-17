using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Domains.Entities;
using TicketThijsMateo.Services;
using TicketThijsMateo.Services.Interfaces;
using TicketThijsMateo.ViewModels;

namespace TicketThijsMateo.Controllers
{
    public class StadiaController : Controller
    {


        private IService<Stadium> stadiumService;


        private readonly IMapper _mapper;

        public StadiaController(IMapper mapper, IService<Stadium> stadiumService)
        {
            _mapper = mapper;
            this.stadiumService = stadiumService;
        }

        public async Task<IActionResult> Index()  // add using System.Threading.Tasks;
        {
            var list = await stadiumService.GetAllAsync();
            List<StadiumVM> listVM = _mapper.Map<List<StadiumVM>>(list);
            return View(listVM);

        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Stadium? stadium = await stadiumService.FindByIdAsync(Convert.ToInt32(id));



            return View(stadium);

        }
    }
}
