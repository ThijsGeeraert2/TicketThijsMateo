using System;
using System.Collections.Generic;

namespace TicketThijsMateo.Domains.Entities;

public partial class Ticket
{
    public int Id { get; set; }

    public DateTime AankoopDatum { get; set; }

    public bool Betaald { get; set; }

    public string Voornaam { get; set; } = null!;

    public string Familienaam { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public int WedstrijdId { get; set; }

    public int? ZitplaatsId { get; set; }

    public virtual Wedstrijden Wedstrijd { get; set; } = null!;

    public virtual ICollection<Wedstrijden> Wedstrijdens { get; set; } = new List<Wedstrijden>();

    public virtual Zitplaatsen? Zitplaats { get; set; }
}
