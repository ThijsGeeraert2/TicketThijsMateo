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

        public bool Betaald { get; set; }
        public int PersoonId { get; set; }

        public int SoortplaatsNr { get; set; }

        public int ZitplaatsId { get; set; }

        public string? Voornaam { get; set; }
        public string? Familienaam { get; set; }

    }

    public class SubscriptionVM
    {
        public DateTime? AankoopDatum { get; set; }

        public int ClubId { get; set; }

        public bool Betaald { get; set; }
        public int PersoonId { get; set; }

        public int ZitplaatsId { get; set; }

        public string? Voornaam { get; set; }
        public string? Familienaam { get; set; }

    }
}
