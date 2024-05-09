﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketThijsMateo.Domains.Context;

namespace TicketThijsMateo.util.PDF.Interfaces
{
    public interface ICreatePDF
    {
        MemoryStream CreatePDFDocumentAsync(Ticket ticket, string logoPath);
    }
}
