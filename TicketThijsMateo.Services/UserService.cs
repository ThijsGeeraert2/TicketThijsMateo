using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketThijsMateo.Domains.Entities;
using TicketThijsMateo.Repositories.Interfaces;
using TicketThijsMateo.Services.Interfaces;

namespace TicketThijsMateo.Services
{
    public class UserService : IService<AspNetUser>
    {
        private IDAO<AspNetUser> _userDAO;

        public UserService(IDAO<AspNetUser> service)
        {
            _userDAO = service;
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
            return await _userDAO.GetAllAsync();
        }

        public Task<IEnumerable<AspNetUser>?> GetAllSoortPlaatsenByStadiumId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AspNetUser>?> GetAllWedstrijdenBetweenClubs(int thuisPloegId, int uitPloegId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(AspNetUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AspNetUser>> GetHotelsNearStadium(string stadiumName)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetLastZetelNummer(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AspNetUser>?> GetAllByWedstrijdId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<AspNetUser?> FindByZitplaatsIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
