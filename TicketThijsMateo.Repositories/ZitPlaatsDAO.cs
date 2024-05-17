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
            
            try
            {
                _ticketDBContext.Entry(entity).State = EntityState.Added;
                await _ticketDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Dao tickets");
            }
        }

        public async Task DeleteAsync(Zitplaatsen entity)
        {
            _ticketDBContext.Entry(entity).State = EntityState.Deleted;

            try
            {
                await _ticketDBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<Zitplaatsen?> FindByIdAsync(int Id)
        {
            try
            {
                return await _ticketDBContext.Zitplaatsens.Where(b => b.SoortplaatsId == Id)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error in DAO");
                throw;

            }
        }

        public async Task<Zitplaatsen?> FindZitplaatsByIdAsync(int Id)
        {
            try
            {
                return await _ticketDBContext.Zitplaatsens.Where(b => b.Id == Id)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error in DAO");
                throw;

            }
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

        public async Task<int> GetLastZetelNummer(int Id)
        {
            try
            {
                var lastZitplaats = await _ticketDBContext.Zitplaatsens
                    .Where(b => b.SoortplaatsId == Id)
                    .OrderByDescending(b => b.ZetelNummer)
                    .FirstOrDefaultAsync();

                return lastZitplaats?.ZetelNummer ?? 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving the last ZetelNummer for SoortplaatsId {Id}", ex);
            }
        }

        public async Task<IEnumerable<Zitplaatsen>?> GetTicketsByUserID(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Zitplaatsen>?> GetAllByWedstrijdId(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Zitplaatsen?> FindByZitplaatsIdAsync(int Id)
        {
            try
            {
                return await _ticketDBContext.Zitplaatsens.Where(b => b.Id == Id)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error in DAO");
                throw;

            }
        }
    }
}
