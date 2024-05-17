using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Domains.Data;
using TicketThijsMateo.Domains.Entities;
using TicketThijsMateo.Repositories.Interfaces;

namespace TicketThijsMateo.Repositories
{
    public class TicketDAO : IDAO<Ticket>
    {
        private readonly TicketDBContext dbContext;

        public TicketDAO(TicketDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(Ticket entity)
        {
            dbContext.Entry(entity).State = EntityState.Added;
            
            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Dao tickets");
            }
        }

        public async Task DeleteAsync(Ticket entity)
        {
            dbContext.Remove(entity).State = EntityState.Deleted;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Dao tickets");
            }

        }

        public async Task<Ticket?> FindByIdAsync(int Id)
        {
            try
            {
                return await dbContext.Tickets.Where(b => b.Id == Id).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine("error in DAO");
                throw;

            }
        }

        public Task<IEnumerable<Ticket>?> GetHotelsNearStadium(string stadiumName)
        {
            throw new NotImplementedException();
        }



        public async Task<IEnumerable<Ticket>?> GetAllAsync()
        {
            try
            {// select * from Bieren
                return await dbContext.Tickets
                    .ToListAsync(); // volgende Namespaces toevoegen bovenaan using System.Linq; using Microsoft.EntityFrameworkCore;	
            }
            catch (Exception ex)
            {
                Console.WriteLine("error in DAO");
                throw;

            }
        }

        public Task<IEnumerable<Ticket>?> GetAllSoortPlaatsenByStadiumId(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ticket>?> GetAllWedstrijdenBetweenClubs(int thuisploegId, int uitploegId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ticket>?> GetAllByWedstrijdId(int Id)
        {
            try
            {
                return await dbContext.Tickets
                    .Where(b => b.WedstrijdId == Id)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error in DAO");
                throw;

            }
        }

        public Task UpdateAsync(Ticket entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetLastZetelNummer(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ticket>?> GetTicketsByUserID(string Id)
        {
            try
            {
                var tickets = await dbContext.Tickets
                    .Where(b => b.UserId == Id)
                    .ToListAsync();

                return tickets;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving tickets for UserID {Id}", ex);
            }
        }

        public async Task<Ticket?> FindZitplaatsByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }


    }
}
