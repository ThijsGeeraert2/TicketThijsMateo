using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketThijsMateo.Services.Interfaces
{
    public interface StadiumIService<T> where T : class
    {
        Task<IEnumerable<T>?> GetAll();
        
    }
}
