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
    public class StadiumIService : IService<Stadium>
    {
        private IDAO<Stadium> _stadiumDAO;

        public StadiumIService(IDAO<Stadium> service)
        {
            _stadiumDAO = service;
        }

        public Task AddAsync(Stadium entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Stadium entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Stadium?> FindByIdAsync(int Id)
        {
            return await _stadiumDAO.FindByIdAsync(Id);
        }

        public async Task<IEnumerable<Stadium>?> GetAllAsync()
        {
            return await _stadiumDAO.GetAllAsync();
        }

        public Task<IEnumerable<Stadium>?> GetAllSoortPlaatsenByStadiumId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Stadium>?> GetAllWedstrijdenBetweenClubs(int thuisPloegId, int uitPloegId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Stadium entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Stadium>> GetHotelsNearStadium(string stadiumName)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetLastZetelNummer(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Stadium>?> GetTicketsByUserID(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Stadium?> FindZitplaatsByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
