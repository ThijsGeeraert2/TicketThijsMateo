using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketThijsMateo.Repositories.Interfaces
{
    public interface StadiumIDAO<T> where T : class
    {
        Task<IEnumerable<T>?> GetAll();
        
    }
}
