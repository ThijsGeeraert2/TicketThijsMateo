using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketThijsMateo.Domains.Context
{
    public class Wedstrijd
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }

        public int MatchDag { get; set; }

    }
}
