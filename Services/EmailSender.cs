using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;

namespace Demo5.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public EmailSender(AppSetting appSetting)
        {
            _mailSettings = appSetting.MailSettings;
        }

        private MailSettings _mailSettings { get; }
        public Task SendEmailAsync(string email, string subject, string message, bool isHtml = true)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_mailSettings.FromEmail);

            mailMessage.To.Add(new MailAddress(email));
            mailMessage.Subject = subject;
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = isHtml;

            NetworkCredential credentials = new NetworkCredential(_mailSettings.Smtp.UserName, _mailSettings.Smtp.Password);

            SmtpClient smtpClient = new SmtpClient(_mailSettings.Smtp.Host)
            {
                Port = _mailSettings.Smtp.Port,
                EnableSsl = _mailSettings.Smtp.Ssl,
                Credentials = credentials
            };

            smtpClient.Send(mailMessage);

            return Task.CompletedTask;

        }
    }
}
