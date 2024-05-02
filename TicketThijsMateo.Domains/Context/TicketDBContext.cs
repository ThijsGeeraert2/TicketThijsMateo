using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketThijsMateo.Domains.Context
{
    public class TicketDBContext : DbContext
    {
        public TicketDBContext(DbContextOptions options) : base(options) { 

        }

        DbSet<Ticket> Tickets {  get; set; }

        DbSet<Abonnement> abonnementen { get; set; }

        DbSet<Club> Clubs { get; set; }

        DbSet<Soortplaats> Soortplaatsen { get; set; }

        DbSet<Stadium> Stadia { get; set; }

        DbSet<Wedstrijd> Wedstrijden {  get; set; }

        DbSet<Zitplaats> Zitplaatsen { get; set; }

    }
}
