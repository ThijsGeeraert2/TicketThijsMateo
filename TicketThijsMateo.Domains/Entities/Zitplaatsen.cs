using System;
using System.Collections.Generic;

namespace TicketThijsMateo.Domains.Entities;

public partial class Zitplaatsen
{
    public int Id { get; set; }

    public int RijNummer { get; set; }

    public int ZetelNummer { get; set; }

    public int? AbbonementId { get; set; }

    public int SoortplaatsId { get; set; }

    public virtual Abonnementen? Abonnementen { get; set; }

    public virtual Soortplaatsen Soortplaats { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
