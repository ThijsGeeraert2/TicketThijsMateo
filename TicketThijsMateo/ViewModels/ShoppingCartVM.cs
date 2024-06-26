﻿using TicketThijsMateo.Domains.Entities;

namespace TicketThijsMateo.ViewModels
{
    public class ShoppingCartVM
    {
        public List<TicketVM>? Ticket { get; set; }
        public List<SubscriptionVM>? Subscription { get; set; }

    }

    public class TicketVM
    {
        public int TicketId { get; set; }
        public DateTime? AankoopDatum { get; set; }

        public int WedstrijdId { get; set; }
        public string? ThuisPloeg { get; set; }
        public string? UitPloeg { get; set; }
        public bool Betaald { get; set; }
        public int PersoonId { get; set; }
        public int SoortplaatsNr { get; set; }

        public decimal? Prijs {  get; set; }
        public Zitplaatsen Zitplaats { get; set; }
        public Soortplaatsen Soortplaats { get; set; }

        public string? Voornaam { get; set; }
        public string? Familienaam { get; set; }

    }

    public class SubscriptionVM
    {
        public DateTime? AankoopDatum { get; set; }
        public DateTime? StartDatum { get; set; }
        public DateTime? EindDatum { get; set; }


        public int ClubId { get; set; }

        public bool Betaald { get; set; }
        public int PersoonId { get; set; }

        public int ZitplaatsId { get; set; }
        public Zitplaatsen Zitplaats { get; set; }
        public int SoortplaatsNr { get; set; }

        public string? Voornaam { get; set; }
        public string? Familienaam { get; set; }

    }
}
