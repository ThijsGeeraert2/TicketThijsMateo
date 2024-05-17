using System.ComponentModel.DataAnnotations;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Domains.Entities;

namespace TicketThijsMateo.ViewModels
{
    public class MailVM
    {
        public Ticket? Ticket { get; set; }
    }
}
