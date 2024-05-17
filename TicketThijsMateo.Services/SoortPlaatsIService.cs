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
    public class SoortPlaatsIService : IService<Soortplaatsen>
    {
        private IDAO<Soortplaatsen> _soortplaatsDAO;

        public SoortPlaatsIService(IDAO<Soortplaatsen> soortplaatsDAO)
        {
            _soortplaatsDAO = soortplaatsDAO;
        }
        public Task AddAsync(Soortplaatsen entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Soortplaatsen entity)
        {
            throw new NotImplementedException();
        }

        public Task<Soortplaatsen?> FindByIdAsync(int Id)
        {
            return _soortplaatsDAO.FindByIdAsync(Id);

        }

        public async Task<IEnumerable<Soortplaatsen>> GetAllAsync()
        {
            return await _soortplaatsDAO.GetAllAsync();

        }

        public async Task<IEnumerable<Soortplaatsen>?> GetAllSoortPlaatsenByStadiumId(int Id)
        {
            return await _soortplaatsDAO.GetAllSoortPlaatsenByStadiumId(Id);
        }

        public Task<IEnumerable<Soortplaatsen>?> GetAllWedstrijdenBetweenClubs(int thuisPloegId, int uitPloegId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Soortplaatsen>?> GetHotelsNearStadium(string stadiumName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Soortplaatsen entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetLastZetelNummer(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Soortplaatsen>?> GetAllByWedstrijdId(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
