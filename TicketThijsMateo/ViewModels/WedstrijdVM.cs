
﻿using TicketThijsMateo.Domains.Context;

namespace TicketThijsMateo.ViewModels

{
    public class WedstrijdVM
    {
        public int Id { get; set; }
      
        public DateTime? Datum { get; set; }

        public int StadiumId { get; set; }

        public string? Stadium { get; set; }

        public string? ThuisPloeg { get; set; }

        public string? UitPloeg { get; set; }

    }
}
