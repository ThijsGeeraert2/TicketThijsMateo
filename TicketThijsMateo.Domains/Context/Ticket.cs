using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketThijsMateo.Domains.Context
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateOnly AankoopDatum { get; set; }

        public bool betaald { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam {  get; set; }
    }
}
