using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace EGStore.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("hassanbayomi.94@gmail.com", "lcjj autj ugaw nhdr")
            };

            return client.SendMailAsync(
                new MailMessage(from: "hassanbayomi.94@gmail.com",
                                to: email,
                                subject,
                                message
                                ));
        }
    }
}
