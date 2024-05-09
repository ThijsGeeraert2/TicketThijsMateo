namespace TicketThijsMateo.ViewModels
{
    public class ShoppingCartVM
    {
        public List<TicketVM>? Ticket { get; set; }
    }

    public class TicketVM
    {
        public DateTime? AankoopDatum { get; set; }

        public int WedstrijdId { get; set; }

        public bool Betaald { get; set; }
        public int PersoonId { get; set; }

        public int ZitplaatsId { get; set; }

        public string? Voornaam { get; set; }
        public string? Familienaam { get; set; }

    }
}
