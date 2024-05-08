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
        public int ThuisPloegId { get; set; }
        public Club ThuisPloeg { get; set; }
        public int UitPloegId { get; set; }
        public Club UitPloeg { get; set; }
        public int StadiumId { get; set; }
        public Stadium Stadium { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
