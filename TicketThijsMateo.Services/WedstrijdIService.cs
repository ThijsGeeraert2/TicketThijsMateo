using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Domains.Entities;
using TicketThijsMateo.Repositories;
using TicketThijsMateo.Repositories.Interfaces;
using TicketThijsMateo.Services.Interfaces;

namespace TicketThijsMateo.Services
{
    public class WedstrijdIService : IService<Wedstrijden>
    {
        private IDAO<Wedstrijden> _wedstrijdDAO;

        public WedstrijdIService(IDAO<Wedstrijden> we)
        {
            _wedstrijdDAO = we;
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
            return await _wedstrijdDAO.FindByIdAsync(Id);
        }

        public async Task<IEnumerable<Wedstrijden>> GetAllAsync()
        {
            return await _wedstrijdDAO.GetAllAsync();

        }

        public Task UpdateAsync(Wedstrijden entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Wedstrijden>> GetHotelsNearStadium(string stadiumName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Wedstrijden>?> GetAllWedstrijdenBetweenClubs(int thuisPloegId, int uitPloegId)
        {
            try
            {
                // Assuming your DAO has the method GetAllWedstrijdenBetweenClubs
                return await _wedstrijdDAO.GetAllWedstrijdenBetweenClubs(thuisPloegId, uitPloegId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in WedstrijdService while fetching matches between clubs: " + ex.Message);
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

        public Task<IEnumerable<Wedstrijden>?> GetAllByWedstrijdId(int Id)
         {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Wedstrijden>?> GetTicketsByUserID(string Id)
        {
            throw new NotImplementedException();
        }


        public async Task<Wedstrijden?> FindZitplaatsByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
