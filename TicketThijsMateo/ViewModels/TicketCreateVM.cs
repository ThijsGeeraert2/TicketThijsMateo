using Microsoft.AspNetCore.Mvc.Rendering;
using TicketThijsMateo.Domains.Entities;

namespace TicketThijsMateo.ViewModels
{
    public class TicketCreateVM
    {
        public string? Naam { get; set; }
        public string? Voornaam { get; set; }
        public int wedstrijdId {  get; set; }

        public string? ThuisPloeg { get; set; }
        public string? UitPloeg { get; set; }
        public int Soortplaatsnr { get; set; }
        public IEnumerable<SelectListItem>? Soortplaatsen { get; set; }
        
    }
}
