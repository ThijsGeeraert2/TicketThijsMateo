using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TicketThijsMateo.util.Mail.Interfaces;
using Microsoft.Extensions.Options;

namespace TicketThijsMateo.util.Mail
{
    public class EmailSend : IEmailSend
    {
        private readonly EmailSettings _emailSettings;

        // Package Microsoft.Extensions.Option zal je moeten installeren
        //Microsoft.Extensions.Options provides a strongly typed way of specifying and accessing settings using dependency injection and acts 
        //as a bridge between configuration
        public EmailSend(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public async Task SendEmailAsync(
        string email, string subject, string message)
        {
            var mail = new MailMessage(); // aanmaken van een mail-object
            mail.To.Add(new MailAddress(email));
            mail.From = new
            MailAddress("mateogheeraert04@gmail.com"); // hier komt jullie Gmail-adres
            mail.Subject = subject;
            mail.Body = message;
            mail.IsBodyHtml = true;
            try
            {
                await SmtpMailAsync(mail);
            }
            catch (Exception ex)
            { throw ex; }
        }

        private async Task SmtpMailAsync(MailMessage mail)
        {
            using (var smtp = new SmtpClient(_emailSettings.MailServer))
            {
                smtp.Port = _emailSettings.MailPort;
                smtp.EnableSsl = true;
                smtp.Credentials =
                new NetworkCredential(_emailSettings.Sender,
                _emailSettings.Password);
                await smtp.SendMailAsync(mail);
            }
        }

        public async Task SendEmailAttachmentAsync(
        string email, string subject, string message, Stream attachmentStream, string attachmentName, bool isBodyHtml)
        {
            var mail = new MailMessage(); // aanmaken van een mail-object
            mail.To.Add(new MailAddress(email));
            mail.From = new
            MailAddress("mateogheeraert04@gmail.com"); // hier komt jullie Gmail-adres
            mail.Subject = subject;
            mail.Body = message;
            mail.Attachments.Add(new Attachment(attachmentStream, attachmentName));
            mail.IsBodyHtml = true;
            try
            {
                await SmtpMailAsync(mail);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
