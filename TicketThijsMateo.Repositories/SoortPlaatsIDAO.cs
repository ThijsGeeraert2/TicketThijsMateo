using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Domains.Data;
using TicketThijsMateo.Domains.Entities;
using TicketThijsMateo.Repositories.Interfaces;

namespace TicketThijsMateo.Repositories
{
    public class SoortPlaatsIDAO : IDAO<Soortplaatsen>
    {
        private readonly TicketDBContext dbContext;

        public SoortPlaatsIDAO(TicketDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(Soortplaatsen entity)
        {
            dbContext.Soortplaatsens.Add(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Soortplaatsen entity)
        {
            dbContext.Soortplaatsens.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Soortplaatsen?> FindByIdAsync(int Id)
        {
            return await dbContext.Soortplaatsens.FindAsync(Id);
        }

        public async Task<IEnumerable<Soortplaatsen>> GetAllAsync()
        {
            return await dbContext.Soortplaatsens.ToListAsync();
        }

        public async Task UpdateAsync(Soortplaatsen entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Soortplaatsen>?> GetAllSoortPlaatsenByStadiumId(int Id)
        {
            try
            {
                return await dbContext.Soortplaatsens.Where(b => b.StadiumId == Id).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting SoortPlaatsen by Stadium ID", ex);
            }
        }

        public Task<IEnumerable<Soortplaatsen>?> GetAllWedstrijdenBetweenClubs(int thuisploegId, int uitploegId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Soortplaatsen>> GetHotelsNearStadium(string stadiumName)
        {
            throw new NotImplementedException();
        }
    }
}
