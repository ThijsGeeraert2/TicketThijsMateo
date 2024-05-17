using System;
using System.Collections.Generic;

namespace TicketThijsMateo.Domains.Entities;

public partial class Stadium
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Adres { get; set; }

    public virtual ICollection<Club> Clubs { get; set; } = new List<Club>();

    public virtual ICollection<Soortplaatsen> Soortplaatsens { get; set; } = new List<Soortplaatsen>();

    public virtual ICollection<Wedstrijden> Wedstrijdens { get; set; } = new List<Wedstrijden>();
}
