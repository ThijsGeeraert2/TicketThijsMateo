using Microsoft.AspNetCore.Mvc.Rendering;

namespace TicketThijsMateo.ViewModels
{
    public class TicketCreateVM
    {
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public int wedstrijdId {  get; set; }
        public int Soortplaatsnr { get; set; }
        public IEnumerable<SelectListItem>? Soortplaatsen { get; set; }
    }
}
