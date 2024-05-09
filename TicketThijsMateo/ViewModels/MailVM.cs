using System.ComponentModel.DataAnnotations;
using TicketThijsMateo.Domains.Context;

namespace TicketThijsMateo.ViewModels
{
    public class MailVM
    {
        public Ticket? Ticket { get; set; }
    }
}
