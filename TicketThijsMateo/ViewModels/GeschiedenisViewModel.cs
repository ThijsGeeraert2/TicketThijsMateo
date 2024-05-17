using TicketThijsMateo.Domains.Entities;

namespace TicketThijsMateo.ViewModels
{
    public class GeschiedenisViewModel
    {
        public List<TicketGeschiedenisVM>? Tickets { get; set; }
        public List<Abonnementen>? Abonnementen { get; set; }
    }
}
