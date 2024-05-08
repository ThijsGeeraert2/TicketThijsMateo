using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Repositories;
using TicketThijsMateo.Repositories.Interfaces;
using TicketThijsMateo.Services.Interfaces;

namespace TicketThijsMateo.Services
{
    public class WedstrijdIService : IService<Wedstrijd>
    {
        private IDAO<Wedstrijd> _wedstrijdDAO;

        public WedstrijdIService(IDAO<Wedstrijd> we)
        {
            _wedstrijdDAO = we;
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
            return await _wedstrijdDAO.FindByIdAsync(Id);
        }

        public async Task<IEnumerable<Wedstrijd>> GetAllAsync()
        {
            return await _wedstrijdDAO.GetAllAsync();

        }

        public Task UpdateAsync(Wedstrijd entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Wedstrijd>?> GetAllWedstrijdenBetweenClubs(int thuisPloegId, int uitPloegId)
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

        public Task<IEnumerable<Wedstrijd>?> GetAllSoortPlaatsenByStadiumId(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
