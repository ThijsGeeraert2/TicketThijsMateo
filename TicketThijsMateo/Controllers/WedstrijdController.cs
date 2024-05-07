using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Services.Interfaces;
using TicketThijsMateo.ViewModels;

namespace TicketThijsMateo.Controllers
{
    public class WedstrijdController : Controller
    {
        private IService<Wedstrijd> wedstrijdService;

        private readonly IMapper _mapper;

        public WedstrijdController(IMapper mapper, IService<Wedstrijd> service)
        {
            _mapper = mapper;
            wedstrijdService = service;
        }

        public async Task<IActionResult> Index()  // add using System.Threading.Tasks;
        {
            var list = await wedstrijdService.GetAllAsync();
            List<WedstrijdVM> listVM = _mapper.Map<List<WedstrijdVM>>(list);
            return View(listVM);


        }
    }
}
