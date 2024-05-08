using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketThijsMateo.Repositories.Interfaces
{
    public interface WedstrijdIDAO<T> where T : class
    {
        Task<IEnumerable<T>?> GetAllWedstrijdenBetweenClubs(int thuisploegId, int uitploegId);

    }
}
