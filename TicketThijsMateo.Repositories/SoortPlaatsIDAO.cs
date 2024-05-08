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
    public class SoortPlaatsIDAO : IDAO<Soortplaats>
    {
        private readonly TicketDBContext dbContext;

        public SoortPlaatsIDAO(TicketDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task AddAsync(Soortplaats entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Soortplaats entity)
        {
            throw new NotImplementedException();
        }

        public Task<Soortplaats?> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Soortplaats>> GetAllAsync()
        {
            try
            {// select * from Bieren
                return await dbContext.Soortplaatsen.ToListAsync();
                    // volgende Namespaces toevoegen bovenaan using System.Linq; using Microsoft.EntityFrameworkCore;	
            }
            catch (Exception ex)
            {
                Console.WriteLine("error in DAO");
                throw;

            }
        }

        public Task<IEnumerable<Soortplaats>?> GetAllWedstrijdenBetweenClubs(int thuisploegId, int uitploegId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Soortplaats entity)
        {
            throw new NotImplementedException();
        }
    }
}
