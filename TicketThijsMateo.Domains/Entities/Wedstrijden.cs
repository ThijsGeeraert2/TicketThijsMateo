using System;
using System.Collections.Generic;

namespace TicketThijsMateo.Domains.Entities;

public partial class Wedstrijden
{
    public int Id { get; set; }

    public DateTime Datum { get; set; }

    public int MatchDag { get; set; }

    public int ThuisPloegId { get; set; }

    public int UitPloegId { get; set; }

    public int StadiumId { get; set; }

    public int? TicketId { get; set; }

    public virtual Stadium Stadium { get; set; } = null!;

    public virtual Club ThuisPloeg { get; set; } = null!;

    public virtual Ticket? Ticket { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual Club UitPloeg { get; set; } = null!;
}
