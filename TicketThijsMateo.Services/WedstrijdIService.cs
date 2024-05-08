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

        public Task<Wedstrijd?> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Wedstrijd>> GetAllAsync()
        {
            return await _wedstrijdDAO.GetAllAsync();

        }

        public Task UpdateAsync(Wedstrijd entity)
        {
            throw new NotImplementedException();
        }
    }
}
