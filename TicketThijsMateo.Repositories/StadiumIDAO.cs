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
    public class StadiumIDAO : IDAO<Stadium>
    {
        private readonly TicketDBContext _ticketDBContext;

        public StadiumIDAO(TicketDBContext ticketDBContext)
        {
            _ticketDBContext = ticketDBContext;
        }

        public Task AddAsync(Stadium entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Stadium entity)
        {
            throw new NotImplementedException();
        }

        public Task<Stadium?> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

     

        public async Task<IEnumerable<Stadium>?> GetAllAsync()
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

        public Task<IEnumerable<Stadium>?> GetAllWedstrijdenBetweenClubs(int thuisploegId, int uitploegId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Stadium entity)
        {
            throw new NotImplementedException();
        }

        

        public Task<IEnumerable<Stadium>?> GetHotelsNearStadium(string stadiumName)
        {
            throw new NotImplementedException();
        }
    }
}
