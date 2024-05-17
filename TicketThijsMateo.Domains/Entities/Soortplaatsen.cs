using System;
using System.Collections.Generic;

namespace TicketThijsMateo.Domains.Entities;

public partial class Soortplaatsen
{
    public int Id { get; set; }

    public string? Naam { get; set; }

    public decimal? Tarief { get; set; }

    public int? Capaciteit { get; set; }

    public int StadiumId { get; set; }

    public virtual Stadium Stadium { get; set; } = null!;

    public virtual ICollection<Zitplaatsen> Zitplaatsens { get; set; } = new List<Zitplaatsen>();

    public static implicit operator Soortplaatsen(Task<Soortplaatsen?> v)
    {
        throw new NotImplementedException();
    }
}
