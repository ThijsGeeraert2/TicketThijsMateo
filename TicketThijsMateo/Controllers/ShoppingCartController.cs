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
using Microsoft.AspNetCore.Mvc;
using TicketThijsMateo.Domains.Context;
using TicketThijsMateo.Extensions;
using TicketThijsMateo.Services.Interfaces;
using TicketThijsMateo.ViewModels;

namespace TicketThijsMateo.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IService<Ticket> ticketService;
        private readonly IMapper _mapper;

        private readonly IEmailSend _emailSend;
        private readonly ICreatePDF _createPDF;
        private readonly IWebHostEnvironment _hostingEnvironment;

        private readonly UserManager<IdentityUser> _userManager;

        public ShoppingCartController(IMapper mapper, IService<Ticket> ticketService, IEmailSend emailSend, ICreatePDF createPDF, IWebHostEnvironment hostingEnvironment, UserManager<IdentityUser> userManager)
        {
            _mapper = mapper;
            this.ticketService = ticketService;

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
                var ticketsVM = cartList.Ticket;

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
                }

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
