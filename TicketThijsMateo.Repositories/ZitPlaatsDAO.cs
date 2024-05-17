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
    public class ZitPlaatsDAO : IDAO<Zitplaatsen>
    {
        private readonly TicketDBContext _ticketDBContext;

        public ZitPlaatsDAO(TicketDBContext ticketDBContext)
        {
            _ticketDBContext = ticketDBContext;
        }

        public async Task AddAsync(Zitplaatsen entity)
        {
            _ticketDBContext.Entry(entity).State = EntityState.Added;

            try
            {
                await _ticketDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Dao tickets");
            }
        }

        public Task DeleteAsync(Zitplaatsen entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Zitplaatsen?> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Zitplaatsen>> GetAllAsync()
        {
            return await _ticketDBContext.Zitplaatsens.ToListAsync();
        }

        public Task<IEnumerable<Zitplaatsen>?> GetAllSoortPlaatsenByStadiumId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Zitplaatsen>?> GetAllWedstrijdenBetweenClubs(int thuisploegId, int uitploegId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Zitplaatsen entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Zitplaatsen>?> GetHotelsNearStadium(string stadiumName)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetLastZetelNummer()
        {
            var allZitplaatsen = await GetAllAsync();

            var lastZitplaats = allZitplaatsen.LastOrDefault();

            return lastZitplaats?.ZetelNummer ?? 0;
        }
    }
}
