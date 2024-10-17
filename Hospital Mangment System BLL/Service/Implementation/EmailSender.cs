using Hospital_Mangment_System_BLL.Service.Abstrsction;
using Hospital_Mangment_System_DAL.DB;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Mangment_System_BLL.Service.Implementation
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailSender(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var mail = new MailMessage()
                {
                    From = new MailAddress(_smtpSettings.SenderEmail, _smtpSettings.SenderName),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true // Allows HTML in email body
                };
                mail.To.Add(new MailAddress(email));

                using (var smtp = new SmtpClient(_smtpSettings.Server, _smtpSettings.Port))
                {
                    smtp.Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);
                    smtp.EnableSsl = _smtpSettings.UseSsl;
                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                // You may want to log this error or handle it in a better way.
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
    }
}
