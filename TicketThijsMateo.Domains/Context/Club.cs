using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketThijsMateo.Domains.Context
{
    public class Club
    {
        public int Id { get; set; }
        public string? Naam { get; set; }

        //FK

        public int StadiumId { get; set; }
        public Stadium? Stadium { get; set; }

        public ICollection<Wedstrijd>? ThuisWedstrijden { get; set;}
        public ICollection<Wedstrijd>? UitWedstrijden { get; set; }
    }
}
