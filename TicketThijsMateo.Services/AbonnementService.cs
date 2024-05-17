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
    public class AbonnementService : IService<Abonnementen>
    {
        private IDAO<Abonnementen> _ticketDAO;

        public AbonnementService(IDAO<Abonnementen> ticketDAO)
        {
            _ticketDAO = ticketDAO;
        }

        public async Task AddAsync(Abonnementen entity)
        {
            await _ticketDAO.AddAsync(entity);
        }

        public Task DeleteAsync(Abonnementen entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Abonnementen?> FindByIdAsync(int Id)
        {
            return await _ticketDAO.FindByIdAsync(Id);
        }

        public async Task<IEnumerable<Abonnementen>> GetAllAsync()
        {
            return await _ticketDAO.GetAllAsync();

        }

        public Task UpdateAsync(Abonnementen entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Abonnementen>> GetHotelsNearStadium(string stadiumName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Abonnementen>?> GetAllWedstrijdenBetweenClubs(int thuisPloegId, int uitPloegId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Abonnementen>?> GetAllSoortPlaatsenByStadiumId(int Id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Abonnementen>?> IService<Abonnementen>.GetAllSoortPlaatsenByStadiumId(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetLastZetelNummer(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Abonnementen>?> GetTicketsByUserID(string Id)
        {
            return await _ticketDAO.GetTicketsByUserID(Id);
        }

        public async Task<Abonnementen?> FindZitplaatsByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}