﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Repositories.Interfaces;
using TicketThijsMateo.Services.Interfaces;

namespace TicketThijsMateo.Services
{
    public class ClubIService : IService<Club>
    {
        private IDAO<Club> _clubDAO;

        public ClubIService(IDAO<Club> clubDAO) {
            _clubDAO = clubDAO;
        }

        public Task AddAsync(Club entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Club entity)
        {
            throw new NotImplementedException();
        }

        public Task<Club?> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Club>> GetAllAsync()
        {
            return await _clubDAO.GetAllAsync();
        }

        public Task<IEnumerable<Club>?> GetAllSoortPlaatsenByStadiumId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Club>?> GetAllWedstrijdenBetweenClubs(int thuisPloegId, int uitPloegId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Club entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Club>> GetHotelsNearStadium(string stadiumName)
        {
            throw new NotImplementedException();
        }
    }
}
