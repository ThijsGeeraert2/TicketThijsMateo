﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Services;
using TicketThijsMateo.Services.Interfaces;
using TicketThijsMateo.ViewModels;

namespace TicketThijsMateo.Controllers
{
    public class HotelController : Controller
    {
        private IService<Hotel> _hotelService;

        private readonly IMapper _mapper;

        public HotelController(IMapper mapper, IService<Hotel> hotelservice)
        {
            _mapper = mapper;
            _hotelService = hotelservice;
        }

        public async Task<IActionResult> Index()  // add using System.Threading.Tasks;
        {
            var list = await _hotelService.GetHotelsNearStadium("Brugge");
            List<HotelVM> listVM = _mapper.Map<List<HotelVM>>(list);
            return View(listVM);


        }
    }
}