using System;
using System.Collections.Generic;

namespace TicketThijsMateo.Domains.Entities;

public partial class Abonnementen
{
    public int Id { get; set; }

    public string? Familienaam { get; set; }

    public string? Voornaam { get; set; }

    public int? ZitplaatsId { get; set; }

    public string UserId { get; set; } = null!;

    public virtual Zitplaatsen? Zitplaats { get; set; }
}
