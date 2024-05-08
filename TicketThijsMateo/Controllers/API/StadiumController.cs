using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Services;
using TicketThijsMateo.Services.Interfaces;
using TicketThijsMateo.ViewModels;

namespace TicketThijsMateo.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumController : ControllerBase
    {
        private IService<Stadium> _stadiumService;
        private readonly IMapper _mapper;

        public StadiumController(IMapper mapper, IService<Stadium> service)
        {
            _stadiumService = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<StadiumVM>> Get()
        {
            try
            {
                var listStadium = await _stadiumService.GetAllAsync();
                var data = _mapper.Map<List<StadiumVM>>(listStadium);

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
