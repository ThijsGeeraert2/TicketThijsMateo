using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketThijsMateo.Domains.Context
{
    public class Abonnement
    {
        public int Id { get; set; }
        public string? Familienaam { get; set; }
        public string? Voornaam { get; set; }
        public int? ZitplaatsID { get; set; }
        public Zitplaats? Zitplaats { get; set; }
    }
}
