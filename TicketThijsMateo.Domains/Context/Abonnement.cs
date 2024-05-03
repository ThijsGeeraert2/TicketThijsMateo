using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int? ZitplaatsId { get; set; }
        public Zitplaats? Zitplaats { get; set; }
        [Column(TypeName = "nvarchar(450)")]
        public string UserId { get; set; }
    }
}
