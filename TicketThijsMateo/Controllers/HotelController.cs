using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Domains.Entities;
using TicketThijsMateo.Services;
using TicketThijsMateo.Services.Interfaces;
using TicketThijsMateo.ViewModels;

namespace TicketThijsMateo.Controllers
{
    public class HotelController : Controller
    {
        private IService<Hotel> _hotelService;
        private IService<Stadium> _stadiumService;


        private readonly IMapper _mapper;

        public HotelController(IMapper mapper, IService<Hotel> hotelservice, IService<Stadium> stadiumService)
        {
            _mapper = mapper;
            _hotelService = hotelservice;
            _stadiumService = stadiumService;
        }

        public async Task<IActionResult> Index(int id)
        {
            Stadium stadium = await _stadiumService.FindByIdAsync(id);
            IEnumerable<Hotel> list = null;

            if (stadium != null)
            {
                list = await _hotelService.GetHotelsNearStadium(stadium.Adres);
            }

            List<HotelVM> listVM = _mapper.Map<List<HotelVM>>(list ?? new List<Hotel>());
            return View(listVM);
        }
    }
}
