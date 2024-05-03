using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketThijsMateo.Domains.Context
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime AankoopDatum { get; set; }

        public bool betaald { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam {  get; set; }

        //FK
        [Column(TypeName = "nvarchar(450)")]
        public string UserId {  get; set; } 
        public int WedstrijdId { get; set; }
        public Wedstrijd? Wedstrijd { get; set; }
        //public int ZitplaatsId { get; set; }
        public Zitplaats? Zitplaats { get; set;}
        
        public ICollection<Wedstrijd>? Wedstrijden { get; set; }
    }
}
