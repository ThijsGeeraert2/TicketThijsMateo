using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Domains.Entities;
using TicketThijsMateo.Extensions;
using TicketThijsMateo.Services;
using TicketThijsMateo.Services.Interfaces;
using TicketThijsMateo.util.Mail.Interfaces;
using TicketThijsMateo.util.PDF.Interfaces;
using TicketThijsMateo.ViewModels;

namespace TicketThijsMateo.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IService<Ticket> _ticketService;
        private IService<Zitplaatsen> _zitPlaatsService;
        private IService<Soortplaatsen> _soortPlaatsenService;
        private IService<Abonnementen> _abonnementService;
        private readonly IMapper _mapper;

        private readonly IEmailSend _emailSend;
        private readonly ICreatePDF _createPDF;
        private readonly IWebHostEnvironment _hostingEnvironment;

        private readonly UserManager<IdentityUser> _userManager;

        public ShoppingCartController(IMapper mapper, IService<Ticket> ticketService, IService<Zitplaatsen> zitplaatsService, IService<Soortplaatsen> soortPlaatsService, IService<Abonnementen> abonnementService, IEmailSend emailSend, ICreatePDF createPDF, IWebHostEnvironment hostingEnvironment, UserManager<IdentityUser> userManager)
        {
            _mapper = mapper;
            _ticketService = ticketService;
            _zitPlaatsService = zitplaatsService;
            _soortPlaatsenService = soortPlaatsService;
            _abonnementService = abonnementService;

            _emailSend = emailSend;
            _createPDF = createPDF;
            _hostingEnvironment = hostingEnvironment;

            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ShoppingCartVM? cartList = HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart");

            if (cartList == null)
            {
                cartList = new ShoppingCartVM();
                HttpContext.Session.SetObject("ShoppingCart", cartList);
            }

            return View(cartList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout()
        {
            ShoppingCartVM cartList = HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart");

            var currentUser = await _userManager.GetUserAsync(User);

            try
            {
                List<TicketVM> ticketsVM = cartList.Ticket;
                List<SubscriptionVM> subscriptionsVM = cartList.Subscription;
                if (ticketsVM != null && ticketsVM.Count > 0)
                {
                    foreach (var ticketVM in ticketsVM)
                    {
                        // Generate PDF document for the current ticket
                        var ticket = _mapper.Map<Ticket>(ticketVM);
                        string logoPath = Path.Combine(_hostingEnvironment.WebRootPath, "images", "proleague.png");
                        var pdfDocument = _createPDF.CreatePDFDocumentAsync(ticket, logoPath);

                        // Create a unique file name for the PDF
                        string pdfFileName = $"ticket_{ticket.Id}_{Guid.NewGuid()}.pdf";

                        // Save the PDF document to a temporary file
                        string pdfFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "pdf", pdfFileName);
                        using (FileStream fileStream = new FileStream(pdfFilePath, FileMode.Create))
                        {
                            pdfDocument.WriteTo(fileStream);
                        }

                        // Send email with PDF attachment
                        using (FileStream attachmentStream = new FileStream(pdfFilePath, FileMode.Open))
                        {
                            await _emailSend.SendEmailAttachmentAsync(currentUser.Email, "Tickets Jupiler Pro League", "Beste, hierbij uw ticket voor de Jupiler Pro League", attachmentStream, pdfFileName);
                        }

                        // Delete the temporary PDF file after sending the email
                        System.IO.File.Delete(pdfFilePath);

                        var lastSeatNumber = await _zitPlaatsService.GetLastZetelNummer();
                        int newSeatNumber = lastSeatNumber + 1;
                        var plaats = await _soortPlaatsenService.FindByIdAsync(ticketVM.SoortplaatsNr);

                        var newZitplaats = new ZitPlaatsVM
                        {
                            RijNummer = 1,
                            ZetelNummer = newSeatNumber,
                            Soortplaats = plaats
                        };

                        var zitplaats = _mapper.Map<Zitplaatsen>(newZitplaats);

                        await _zitPlaatsService.AddAsync(zitplaats);

                        ticketVM.Zitplaats = zitplaats;

                        var ticketEntity = _mapper.Map<Ticket>(ticketVM);
                        ticketEntity.UserId = currentUser.Id;

                        await _ticketService.AddAsync(ticketEntity);

                    }
                }
                if (subscriptionsVM != null && subscriptionsVM.Count > 0) {
                    foreach (var subscriptionVM in subscriptionsVM)
                    {
                        // Generate PDF document for the current ticket
                        var abbonement = _mapper.Map<Abonnementen>(subscriptionVM);
                        string logoPath = Path.Combine(_hostingEnvironment.WebRootPath, "images", "proleague.png");
                        var pdfDocument = _createPDF.CreatePDFDocumentAsync(abbonement, logoPath);

                        // Create a unique file name for the PDF
                        string pdfFileName = $"ticket_{abbonement.Id}_{Guid.NewGuid()}.pdf";

                        // Save the PDF document to a temporary file
                        string pdfFilePath = Path.Combine(_hostingEnvironment.WebRootPath, "pdf", pdfFileName);
                        using (FileStream fileStream = new FileStream(pdfFilePath, FileMode.Create))
                        {
                            pdfDocument.WriteTo(fileStream);
                        }

                        // Send email with PDF attachment
                        using (FileStream attachmentStream = new FileStream(pdfFilePath, FileMode.Open))
                        {
                            await _emailSend.SendEmailAttachmentAsync(currentUser.Email, "Tickets Jupiler Pro League", "Beste, hierbij uw ticket voor de Jupiler Pro League", attachmentStream, pdfFileName);
                        }

                        // Delete the temporary PDF file after sending the email
                        System.IO.File.Delete(pdfFilePath);

                        var lastSeatNumber = await _zitPlaatsService.GetLastZetelNummer();
                        int newSeatNumber = lastSeatNumber + 1;
                        var plaats = await _soortPlaatsenService.FindByIdAsync(subscriptionVM.SoortplaatsNr);

                        var newZitplaats = new ZitPlaatsVM
                        {
                            RijNummer = 1,
                            ZetelNummer = newSeatNumber,
                            Soortplaats = plaats
                        };

                        var zitplaats = _mapper.Map<Zitplaatsen>(newZitplaats);

                        await _zitPlaatsService.AddAsync(zitplaats);

                        subscriptionVM.Zitplaats = zitplaats;

                        var abonnementEntity = _mapper.Map<Abonnementen>(subscriptionVM);
                        abonnementEntity.UserId = currentUser.Id;

                        await _abonnementService.AddAsync(abonnementEntity);

                    }
                }        
            HttpContext.Session.Remove("ShoppingCart");

            return View("Thanks");
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Failed to send email: {ex.Message}";
                return View();
            }
        }



        public IActionResult Delete(int? wedstrijdId)
        {
            if (wedstrijdId == null)
            {
                return BadRequest("Invalid item id.");
            }

            ShoppingCartVM? cartList = HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart");

            if (cartList == null)
            {
                return NotFound("Shopping cart not found.");
            }

            var itemToRemove = cartList.Ticket.FirstOrDefault(t => t.WedstrijdId == wedstrijdId);

            if (itemToRemove != null)
            {
                cartList.Ticket.Remove(itemToRemove);
                HttpContext.Session.SetObject("ShoppingCart", cartList);
            }
            else
            {
                return NotFound("Item not found in the shopping cart.");
            }

            return RedirectToAction("Index");
        }

        public IActionResult DeleteSubscription(int? clubId)
        {
            if (clubId == null)
            {
                return BadRequest("Invalid item id.");
            }

            ShoppingCartVM? cartList = HttpContext.Session.GetObject<ShoppingCartVM>("ShoppingCart");

            if (cartList == null)
            {
                return NotFound("Shopping cart not found.");
            }

            var itemToRemove = cartList.Subscription.FirstOrDefault(t => t.ClubId == clubId);

            if (itemToRemove != null)
            {
                cartList.Subscription.Remove(itemToRemove);
                HttpContext.Session.SetObject("ShoppingCart", cartList);
            }
            else
            {
                return NotFound("Item not found in the shopping cart.");
            }

            return RedirectToAction("Index");
        }
    }
}