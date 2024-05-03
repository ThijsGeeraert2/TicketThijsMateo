using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketThijsMateo.Domains.Context
{
    public class Zitplaats
    {
        public int Id { get; set; }
        public int RijNummer { get; set; }
        public int ZetelNummer { get; set; }
        public int? AbbonementId { get; set; }
        public Abonnement? Abonnement { get; set; }
        public int SoortplaatsId { get; set; }
        public Soortplaats? Soortplaats { get; set; }

    }
}
