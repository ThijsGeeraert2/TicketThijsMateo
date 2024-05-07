﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Repositories.Interfaces;

namespace TicketThijsMateo.Repositories
{
    public class WedstrijdDAO : IDAO<Wedstrijd>
    {
        private readonly TicketDBContext _ticketDBContext;

        public WedstrijdDAO(TicketDBContext ticketDBContext)
        {
            _ticketDBContext = ticketDBContext;
        }

        public async Task<IEnumerable<Wedstrijd>?> GetAll()
        {
            try
            {
                return await _ticketDBContext.Wedstrijden.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error in DAO");
                throw;
            }
        }

        public async Task<IEnumerable<Wedstrijd>?> GetWedstrijdenBetweenClubs(int thuisploegId, int uitploegId)
        {
            try
            {
 
                return await _ticketDBContext.Wedstrijden
                    .Where(w => w.ThuisPloegId == thuisploegId && w.UitPloegId == uitploegId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in DAO while fetching matches between clubs: " + ex.Message);
                throw;
            }
        }

    }
}
