using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Repositories;
using TicketThijsMateo.Repositories.Interfaces;
using TicketThijsMateo.Services.Interfaces;

namespace TicketThijsMateo.Services
{
    public class StadiumService: StadiumIService<Stadium>
    {
        private StadiumIDAO<Stadium> _stadiumDAO;

        public StadiumService(StadiumIDAO<Stadium> service)
        {
            _stadiumDAO = service;
        }

        public async Task<IEnumerable<Stadium>?> GetAll()
        {
            return await _stadiumDAO.GetAll();
        }

       
    }
}
