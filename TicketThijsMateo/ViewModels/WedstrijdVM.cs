
﻿using TicketThijsMateo.Domains.Context;

namespace TicketThijsMateo.ViewModels

{
    public class WedstrijdVM
    {
        public int Id { get; set; }
      
        public string? Datum { get; set; }

        public string? Stadium { get; set; }

        public string? ThuisPloeg { get; set; }

        public string? UitPloeg { get; set; }

    }
}
