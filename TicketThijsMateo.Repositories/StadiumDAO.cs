using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Repositories.Interfaces;

namespace TicketThijsMateo.Repositories
{
    public class StadiumDAO : StadiumIDAO<Stadium>
    {
        private readonly TicketDBContext _ticketDBContext;

        public StadiumDAO(TicketDBContext ticketDBContext)
        {
            _ticketDBContext = ticketDBContext;
        }

        public async Task<IEnumerable<Stadium>?> GetAll()
        {
            try
            {
                return await _ticketDBContext.Stadia.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error in DAO");
                throw;
            }
        }
    }
}
