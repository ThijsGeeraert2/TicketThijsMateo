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

        //DbSet<Ticket> Ticket {  get; set; }
    }
}
