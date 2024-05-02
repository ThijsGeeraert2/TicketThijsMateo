using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketThijsMateo.Domains.Context
{
    public class Stadium
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Adres { get; set; }

        //FK
        public int ClubId { get; set; }
        public Club Club { get; set; }

        
        public ICollection<Soortplaats> Soortplaatsen { get; set; } 
    
    }
}
