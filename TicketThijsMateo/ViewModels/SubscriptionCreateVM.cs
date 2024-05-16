using Microsoft.AspNetCore.Mvc.Rendering;

namespace TicketThijsMateo.ViewModels
{
    public class SubscriptionCreateVM
    {
        public string? Naam { get; set; }
        public string? Voornaam { get; set; }
        public int ClubId { get; set; }
        public string? ClubNaam { get; set; }
        public int Soortplaatsnr { get; set; }
        public IEnumerable<SelectListItem>? Soortplaatsen { get; set; }
    }
}
