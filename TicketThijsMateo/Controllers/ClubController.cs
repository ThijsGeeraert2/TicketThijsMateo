using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Services.Interfaces;
using TicketThijsMateo.ViewModels;

namespace TicketThijsMateo.Controllers
{
    public class ClubController : Controller
    {
        private IService<Club> clubService;

        private readonly IMapper _mapper;

        public ClubController(IMapper mapper, IService<Club> clubservice)
        {
            _mapper = mapper;
            clubService = clubservice;
        }

        public async Task<IActionResult> Index()  // add using System.Threading.Tasks;
        {
            var list = await clubService.GetAllAsync();
            List<ClubVM> listVM = _mapper.Map<List<ClubVM>>(list);
            return View(listVM);


        }
    }
}
