using System;
using System.Collections.Generic;

namespace TicketThijsMateo.Domains.Entities;

public partial class Club
{
    public int Id { get; set; }

    public string? Naam { get; set; }

    public int StadiumId { get; set; }

    public virtual Stadium Stadium { get; set; } = null!;

    public virtual ICollection<Wedstrijden> WedstrijdenThuisPloegs { get; set; } = new List<Wedstrijden>();

    public virtual ICollection<Wedstrijden> WedstrijdenUitPloegs { get; set; } = new List<Wedstrijden>();
}
