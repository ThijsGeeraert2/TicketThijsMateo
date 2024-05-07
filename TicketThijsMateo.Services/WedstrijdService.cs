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
    public class WedstrijdService : IService<Wedstrijd>
    {
        private IDAO<Wedstrijd> _wedstrijdDAO;

        public WedstrijdService(IDAO<Wedstrijd> service)
        {
            _wedstrijdDAO = service;
        }

        public async Task<IEnumerable<Wedstrijd>?> GetAll()
        {
            return await _wedstrijdDAO.GetAll();
        }

        //public async Task<IEnumerable<Wedstrijd>?> GetAllWedstrijdenBetweenClubs(int thuisPloegId, int uitPloegId)
        //{
        //    try
        //    {
        //        // Assuming your DAO has the method GetAllWedstrijdenBetweenClubs
        //        return await _wedstrijdDAO.GetAllWedstrijdenBetweenClubs(thuisPloegId, uitPloegId);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error in WedstrijdService while fetching matches between clubs: " + ex.Message);
        //        throw;
        //    }
        //}

    }
}
