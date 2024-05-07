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
        public TicketDBContext(DbContextOptions<TicketDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wedstrijd>()
                .HasOne(w => w.Stadium)
                .WithMany()
                .HasForeignKey(w => w.StadiumId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()

           .HasOne(t => t.Wedstrijd)

           .WithMany(w => w.Tickets)

           .HasForeignKey(t => t.WedstrijdId);
        }

        DbSet<Ticket> Tickets { get; set; }
        DbSet<Abonnement> Abonnementen { get; set; }
        public DbSet<Club> Clubs { get; set; }
        DbSet<Soortplaats> Soortplaatsen { get; set; }
        DbSet<Stadium> Stadia { get; set; }
        DbSet<Wedstrijd> Wedstrijden { get; set; }
        DbSet<Zitplaats> Zitplaatsen { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = ticketsthijsmateo.database.windows.net; Initial Catalog = TicketDB24; User ID =Beheerder; Password = Hallo1234; MultipleActiveResultSets = True; Encrypt = True; TrustServerCertificate = True; ");
            }
        }

    }


}
