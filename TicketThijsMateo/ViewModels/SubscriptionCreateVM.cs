using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TicketThijsMateo.ViewModels
{
    public class SubscriptionCreateVM
    {
        public string? Naam { get; set; }
        public string? Voornaam { get; set; }
        public int ClubId { get; set; }
        public string? ClubNaam { get; set; }

        [Required(ErrorMessage = "Soortplaatsnr is required.")]
        public int Soortplaatsnr { get; set; }
        [Required(ErrorMessage = "Soortplaatsnr is required.")]

        public IEnumerable<SelectListItem>? Soortplaatsen { get; set; }
    }
}
