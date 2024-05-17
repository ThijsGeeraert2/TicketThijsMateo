using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Domains.Entities;
using TicketThijsMateo.Repositories.Interfaces;
using TicketThijsMateo.Services.Interfaces;

namespace TicketThijsMateo.Services
{
    public class TicketService : IService<Ticket>
    {
        private IDAO<Ticket> _ticketDAO;

        public TicketService(IDAO<Ticket> ticketDAO)
        {
            _ticketDAO = ticketDAO;
        }

        public async Task AddAsync(Ticket entity)
        {
            await _ticketDAO.AddAsync(entity);
        }

        public Task DeleteAsync(Ticket entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Ticket?> FindByIdAsync(int Id)
        {
            return await _ticketDAO.FindByIdAsync(Id);
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return await _ticketDAO.GetAllAsync();

        }

        public Task UpdateAsync(Ticket entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ticket>> GetHotelsNearStadium(string stadiumName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ticket>?> GetAllWedstrijdenBetweenClubs(int thuisPloegId, int uitPloegId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Wedstrijden>?> GetAllSoortPlaatsenByStadiumId(int Id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Ticket>?> IService<Ticket>.GetAllSoortPlaatsenByStadiumId(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetLastZetelNummer(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ticket>?> GetTicketsByUserID(string Id)
        {
            return await _ticketDAO.GetTicketsByUserID(Id);
        }
    }
}