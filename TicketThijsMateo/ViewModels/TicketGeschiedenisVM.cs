using TicketThijsMateo.Domains.Entities;

namespace TicketThijsMateo.ViewModels
{
    public class TicketGeschiedenisVM
    {
        public Ticket Ticket { get; set; }
        public string ThuisPloegNaam { get; set; }
        public string UitPloegNaam { get; set; }
        public DateTime WedstrijdDatum { get; set; }
    }
}
