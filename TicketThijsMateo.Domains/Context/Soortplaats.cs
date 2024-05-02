using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketThijsMateo.Domains.Context
{
    public class Soortplaats
    {
        public int Id { get; set; }
        public string? Naam { get; set; }

        public decimal? Tarief { get; set; }
        public int? Capaciteit { get; set; }
        

    }
}
