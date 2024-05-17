using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketThijsMateo.Domains.Entities;
using TicketThijsMateo.Repositories;
using TicketThijsMateo.Repositories.Interfaces;
using TicketThijsMateo.Services.Interfaces;

namespace TicketThijsMateo.Services
{
    public class ZitPlaatsService : IService<Zitplaatsen>
    {
        private IDAO<Zitplaatsen> _zitPlaatsDAO;

        public ZitPlaatsService(IDAO<Zitplaatsen> service)
        {
            _zitPlaatsDAO = service;
        }

        public async Task AddAsync(Zitplaatsen entity)
        {
            await _zitPlaatsDAO.AddAsync(entity);
        }

        public Task DeleteAsync(Zitplaatsen entity)
        {
            return _zitPlaatsDAO.DeleteAsync(entity);
        }

        public async Task<Zitplaatsen?> FindByIdAsync(int Id)
        {
            return await _zitPlaatsDAO.FindByIdAsync(Id);
        }

        public async Task<IEnumerable<Zitplaatsen>?> GetAllAsync()
        {
            return await _zitPlaatsDAO.GetAllAsync();
        }

        public Task<IEnumerable<Zitplaatsen>?> GetAllSoortPlaatsenByStadiumId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Zitplaatsen>?> GetAllWedstrijdenBetweenClubs(int thuisPloegId, int uitPloegId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Zitplaatsen entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Zitplaatsen>> GetHotelsNearStadium(string stadiumName)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetLastZetelNummer(int Id)
        {
            return await _zitPlaatsDAO.GetLastZetelNummer(Id);
        }

        public async Task<IEnumerable<Zitplaatsen>?> GetTicketsByUserID(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Zitplaatsen?> FindZitplaatsByIdAsync(int Id)
        {
            return await _zitPlaatsDAO.FindZitplaatsByIdAsync(Id);
        }

        public Task<IEnumerable<Zitplaatsen>?> GetAllByWedstrijdId(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
