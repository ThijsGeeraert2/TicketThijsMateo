using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketThijsMateo.Repositories.Interfaces
{
    public interface IDAO<T> where T : class
    {
<<<<<<< HEAD
        Task<IEnumerable<T>?> GetAll();
    }


=======
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T?> FindByIdAsync(int Id);
    }
>>>>>>> d9d66ab619fdb6e25e5b3a0dd0f3c94d4613202d
}
