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
    public class WedstrijdIDAO : IDAO<Wedstrijd>
    {
        private readonly TicketDBContext dbContext;
        public WedstrijdIDAO(TicketDBContext ticketDBContext) {
            dbContext = ticketDBContext;
        }
        public Task AddAsync(Wedstrijd entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Wedstrijd entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Wedstrijd?> FindByIdAsync(int Id)
        {
            try
            {
                return await dbContext.Wedstrijden.Where(b => b.Id == Id)
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

        public async Task<IEnumerable<Wedstrijd>> GetAllAsync()
        {
            try
            {// select * from Bieren
                return await dbContext.Wedstrijden
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

        public Task UpdateAsync(Wedstrijd entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Wedstrijd>?> GetAllWedstrijdenBetweenClubs(int thuisploegId, int uitploegId)
        {
            try
            {

                return await dbContext.Wedstrijden
                    .Where(w => w.ThuisPloegId == thuisploegId && w.UitPloegId == uitploegId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in DAO while fetching matches between clubs: " + ex.Message);
                throw;
            }
        }

        public Task<IEnumerable<Wedstrijd>?> GetAllSoortPlaatsenByStadiumId(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
