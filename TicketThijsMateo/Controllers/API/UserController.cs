using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketThijsMateo.Domains.Entities;
using TicketThijsMateo.Services.Interfaces;
using TicketThijsMateo.ViewModels;

namespace TicketThijsMateo.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IService<AspNetUser> _userService;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper, IService<AspNetUser> service)
        {
            _userService = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<UserVM>> Get()
        {
            try
            {
                var listUsers = await _userService.GetAllAsync();
                var data = _mapper.Map<List<UserVM>>(listUsers);

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

