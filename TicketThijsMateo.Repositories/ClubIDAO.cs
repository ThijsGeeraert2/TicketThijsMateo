using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketThijsMateo.Domains.Data;
using TicketThijsMateo.Domains.Entities;
using TicketThijsMateo.Repositories.Interfaces;

namespace TicketThijsMateo.Repositories
{
    public class ClubIDAO : IDAO<Club>
    {
        private readonly TicketDBContext dbContext;

        public ClubIDAO(TicketDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task AddAsync(Club entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Club entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Club?> FindByIdAsync(int Id)
        {
            try
            {
                return await dbContext.Clubs.Where(b => b.Id == Id)
                    .Include(b => b.Stadium)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error in DAO");
                throw;

            }
        }

        public Task<IEnumerable<Club>?> GetHotelsNearStadium(string stadiumName)
        {
            throw new NotImplementedException();
        }



        public async Task<IEnumerable<Club>?> GetAllAsync()
        {
            try
            {// select * from Bieren
                return await dbContext.Clubs
                    .ToListAsync(); // volgende Namespaces toevoegen bovenaan using System.Linq; using Microsoft.EntityFrameworkCore;	
            }
            catch (Exception ex)
            {
                Console.WriteLine("error in DAO");
                throw;

            }
        }

        public Task<IEnumerable<Club>?> GetAllSoortPlaatsenByStadiumId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Club>?> GetAllWedstrijdenBetweenClubs(int thuisploegId, int uitploegId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Club entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetLastZetelNummer(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
