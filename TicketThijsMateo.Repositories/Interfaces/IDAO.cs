using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketThijsMateo.Repositories.Interfaces
{
    public interface IDAO<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T?> FindByIdAsync(int Id);
        Task<IEnumerable<T>?> GetAllWedstrijdenBetweenClubs(int thuisploegId, int uitploegId);
        Task<IEnumerable<T>> GetHotelsNearStadium(string stadiumName);
        Task<IEnumerable<T>?> GetAllSoortPlaatsenByStadiumId(int Id);

        Task<IEnumerable<T>?> GetAllByWedstrijdId(int Id);
        Task <T?> FindByZitplaatsIdAsync(int Id);
        
        Task<int> GetLastZetelNummer(int Id);
       

    }


}
