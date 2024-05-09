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
    public class SoortPlaatsIService : IService<Soortplaats>
    {
        private IDAO<Soortplaats> _soortplaatsDAO;

        public SoortPlaatsIService(IDAO<Soortplaats> soortplaatsDAO)
        {
            _soortplaatsDAO = soortplaatsDAO;
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
            return await _soortplaatsDAO.GetAllAsync();

        }

        public async Task<IEnumerable<Soortplaats>?> GetAllSoortPlaatsenByStadiumId(int Id)
        {
            return await _soortplaatsDAO.GetAllSoortPlaatsenByStadiumId(Id);
        }

        public Task<IEnumerable<Soortplaats>?> GetAllWedstrijdenBetweenClubs(int thuisPloegId, int uitPloegId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Soortplaats>?> GetHotelsNearStadium(string stadiumName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Soortplaats entity)
        {
            throw new NotImplementedException();
        }
    }
}
