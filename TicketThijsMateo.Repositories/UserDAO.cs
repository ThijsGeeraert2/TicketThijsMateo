using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketThijsMateo.Domains.Data;
using TicketThijsMateo.Domains.Entities;
using TicketThijsMateo.Repositories.Interfaces;

namespace TicketThijsMateo.Repositories
{
    public class UserDAO : IDAO<AspNetUser>
    {
        private readonly TicketDBContext _ticketDBContext;

        public UserDAO(TicketDBContext ticketDBContext)
        {
            _ticketDBContext = ticketDBContext;
        }

        public Task AddAsync(AspNetUser entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(AspNetUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task<AspNetUser?> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }



        public async Task<IEnumerable<AspNetUser>> GetAllAsync()
        {
            try
            {
                return await _ticketDBContext.AspNetUsers.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error in DAO");
                throw;
            }
        }

        public Task<IEnumerable<AspNetUser>?> GetAllSoortPlaatsenByStadiumId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AspNetUser>?> GetAllWedstrijdenBetweenClubs(int thuisploegId, int uitploegId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(AspNetUser entity)
        {
            throw new NotImplementedException();
        }



        public Task<IEnumerable<AspNetUser>?> GetHotelsNearStadium(string stadiumName)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetLastZetelNummer(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AspNetUser>?> GetTicketsByUserID(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<AspNetUser?> FindZitplaatsByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AspNetUser>?> GetAllByWedstrijdId(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
