using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Services.Interfaces;
using TicketThijsMateo.ViewModels;

namespace TicketThijsMateo.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class WedstrijdController : ControllerBase
    {
        private IService<Wedstrijd> _wedstrijdService;
        private readonly IMapper _mapper;

        public WedstrijdController(IMapper mapper, IService<Wedstrijd> service)
        {
            _wedstrijdService = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<WedstrijdVM>> Get(int thuisPloegId, int uitPloegId)
        {
            try
            {
                var listWedstrijden = await _wedstrijdService.GetAllWedstrijdenBetweenClubs(thuisPloegId, uitPloegId);
                var data = _mapper.Map<List<WedstrijdVM>>(listWedstrijden);

                if (data == null)
                {// Als de gegevens niet worden gevonden, retourneer een 404 Not Found-status
                    return NotFound();
                }
                // Retourneer de gegevens als alles goed is verlopen
                // HTTP-statuscode 200
                return Ok(data);
            }
            catch (Exception ex)
            {
                // Als er een fout optreedt, retourneer een 500 Internal Server Error-status
                return StatusCode(500, new { error = ex.Message });
            }
        }

    }
}
