using Microsoft.AspNetCore.Mvc;
using TicketThijsMateo.Domains.Entities;
using TicketThijsMateo.util.Mail.Interfaces;
using TicketThijsMateo.util.PDF.Interfaces;
using TicketThijsMateo.ViewModels;

namespace TicketThijsMateo.Controllers
{
    public class SendController : Controller
    {
        private readonly IEmailSend _emailSend;
        private readonly ICreatePDF _createPDF;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public SendController(IEmailSend emailSend, ICreatePDF createPDF, IWebHostEnvironment hostingEnvironment)
        {
            _emailSend = emailSend;
            _createPDF = createPDF;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IndexAsync(MailVM entityVM)
        {
            
            try
            {

                string pdfFile = "ticket" + DateTime.Now.Year;
                var pdfFileName = $"{pdfFile}_{Guid.NewGuid()}.pdf";
                var tickets = new List<Ticket> {
                        new Ticket { Id=1, AankoopDatum=DateTime.Now, Betaald = false, Voornaam="Mateo", Familienaam="Gheeraert", UserId = "1234", Wedstrijd=null, Zitplaats=null  },
                    };

                string logoPath = Path.Combine(_hostingEnvironment.WebRootPath, "images", "proleague.png");

                var pdfDocument = _createPDF.CreatePDFDocumentAsync(tickets[0], logoPath);

                // Als de map pdf nog niet bestaat in de wwwroot map,
                // maak deze dan aan voordat je het PDF-document opslaat.
                string pdfFolderPath = Path.Combine(_hostingEnvironment.WebRootPath, "pdf");
                Directory.CreateDirectory(pdfFolderPath);
                //Combineer het pad naar de wwwroot map met het gewenste subpad en bestandsnaam voor het PDF-document.
                string filePath = Path.Combine(pdfFolderPath, "example.pdf");
                // Opslaan van de MemoryStream naar een bestand
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    pdfDocument.WriteTo(fileStream);
                }

                await _emailSend.SendEmailAttachmentAsync("Mateogheeraert04@gmail.com", "Mateo", "Allo", pdfDocument, pdfFileName);



                return View("Thanks");
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Failed to send email: {ex.Message}";
            }

            return View(entityVM);
        }
          
    }
}
