using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketThijsMateo.Domains.Data;
using TicketThijsMateo.Domains.Entities;
using TicketThijsMateo.Repositories.Interfaces;

namespace TicketThijsMateo.Repositories
{
    public class AbonnementDAO : IDAO<Abonnementen>
    {
        private readonly TicketDBContext dbContext;

        public AbonnementDAO(TicketDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(Abonnementen entity)
        {
            dbContext.Entry(entity).State = EntityState.Added;
            await dbContext.SaveChangesAsync();
            //try
            //{

            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Error Dao tickets");
            //}
        }

        public Task DeleteAsync(Abonnementen entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Abonnementen?> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Abonnementen>?> GetHotelsNearStadium(string stadiumName)
        {
            throw new NotImplementedException();
        }



        public async Task<IEnumerable<Abonnementen>?> GetAllAsync()
        {
            try
            {// select * from Bieren
                return await dbContext.Abonnementens
                    .ToListAsync(); // volgende Namespaces toevoegen bovenaan using System.Linq; using Microsoft.EntityFrameworkCore;	
            }
            catch (Exception ex)
            {
                Console.WriteLine("error in DAO");
                throw;

            }
        }

        public Task<IEnumerable<Abonnementen>?> GetAllSoortPlaatsenByStadiumId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Abonnementen>?> GetAllWedstrijdenBetweenClubs(int thuisploegId, int uitploegId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Abonnementen entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetLastZetelNummer()
        {
            throw new NotImplementedException();
        }
    }
}

