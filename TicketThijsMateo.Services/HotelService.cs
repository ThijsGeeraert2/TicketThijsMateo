using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SerpApi;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Services.Interfaces;
using TicketThijsMateo.Repositories.Interfaces; // If needed for your application

namespace TicketThijsMateo.Services
{
    public class HotelService : IService<Hotel>
    {
        private const string ApiKey = "bc035837a8cbd877cdc91e7a74b5f68b649b5fe23196cd8dfa2aa98c6319798c";

        private IDAO<Hotel> _hotelDAO;

        public HotelService(IDAO<Hotel> hotelDAO)
        {
            _hotelDAO = hotelDAO;
        }

        public Task AddAsync(Hotel entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Hotel entity)
        {
            throw new NotImplementedException();
        }

        public Task<Hotel?> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Hotel>?> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Hotel>?> GetAllWedstrijdenBetweenClubs(int thuisPloegId, int uitPloegId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Hotel entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Hotel>> GetHotelsNearStadium(string stadiumName)
        {
            return await _hotelDAO.GetHotelsNearStadium(stadiumName);
        }
    }
}
