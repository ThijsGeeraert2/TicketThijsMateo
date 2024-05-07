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

        public Task<Wedstrijd?> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Wedstrijd>> GetAllAsync()
        {
            try
            {// select * from Bieren
                return await dbContext.Wedstrijden
                    .Include(b => b.Stadium)
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
    }
}
