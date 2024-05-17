using TicketThijsMateo.Domains.Entities;

namespace TicketThijsMateo.ViewModels
{
    public class ZitPlaatsVM
    {
        public int RijNummer { get; set; }

        public int ZetelNummer { get; set; }
        public virtual Soortplaatsen Soortplaats { get; set; } = null!;
    }
}
