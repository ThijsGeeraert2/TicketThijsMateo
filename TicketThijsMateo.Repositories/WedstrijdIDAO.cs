using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Domains.Data;
using TicketThijsMateo.Domains.Entities;
using TicketThijsMateo.Repositories.Interfaces;

namespace TicketThijsMateo.Repositories
{
    public class WedstrijdIDAO : IDAO<Wedstrijden>
    {
        private readonly TicketDBContext dbContext;
        public WedstrijdIDAO(TicketDBContext ticketDBContext) {
            dbContext = ticketDBContext;
        }
        public Task AddAsync(Wedstrijden entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Wedstrijden entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Wedstrijden?> FindByIdAsync(int Id)
        {
            try
            {
                return await dbContext.Wedstrijdens.Where(b => b.Id == Id)
                    .Include(b => b.Stadium)
                    .Include(b => b.ThuisPloeg)
                    .Include(b => b.UitPloeg)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error in DAO");
                throw;

            }
        }

        public async Task<IEnumerable<Wedstrijden>> GetAllAsync()
        {
            try
            {// select * from Bieren
                return await dbContext.Wedstrijdens
                    .Include(b => b.Stadium)
                    .Include(b => b.ThuisPloeg)
                    .Include(b => b.UitPloeg)
                    .ToListAsync(); // volgende Namespaces toevoegen bovenaan using System.Linq; using Microsoft.EntityFrameworkCore;	
            }
            catch (Exception ex)
            {
                Console.WriteLine("error in DAO", ex);
                throw;

            }
        }

        public Task UpdateAsync(Wedstrijden entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Wedstrijden>?> GetHotelsNearStadium(string stadiumName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Wedstrijden>?> GetAllWedstrijdenBetweenClubs(int thuisploegId, int uitploegId)
        {
            try
            {

                return await dbContext.Wedstrijdens
                    .Where(w => w.ThuisPloegId == thuisploegId && w.UitPloegId == uitploegId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in DAO while fetching matches between clubs: " + ex.Message);
                throw;
            }
        }

        public Task<IEnumerable<Wedstrijden>?> GetAllSoortPlaatsenByStadiumId(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetLastZetelNummer(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
