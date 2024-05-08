﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketThijsMateo.Services.Interfaces
{
    public interface WedstrijdIService<T> where T : class
    {
        Task<IEnumerable<T>?> GetAllWedstrijdenBetweenClubs(int thuisPloegId, int uitPloegId);

    }
}