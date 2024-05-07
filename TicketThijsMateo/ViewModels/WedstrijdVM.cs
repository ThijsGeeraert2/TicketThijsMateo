using TicketThijsMateo.Domains.Context;

namespace TicketThijsMateo.ViewModels
{
    public class WedstrijdVM
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public int MatchDag { get; set; }
        public int ThuisPloegId { get; set; }
        public int UitPloegId { get; set; }
        public int StadiumId { get; set; }
    }
}
