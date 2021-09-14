using Microsoft.Extensions.Logging;
using Quartz;
using System.Net.Mail;
using System.Threading.Tasks;
using QuotesWebApi.Worker;
using QuotesWebApi.Quartz;
using Quartz.Impl;
using Quartz.Spi;
using Microsoft.Extensions.DependencyInjection;

namespace QuotesWebApi.Worker
{
    public class EmailSender : IEmailSender
    {

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var from = "****@gmail.com";
            var pass = "****";
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(from, pass);
            client.EnableSsl = true;
            var mail = new MailMessage(from, email);
            mail.Subject = subject;
            mail.Body = message;
            mail.IsBodyHtml = true;
            return client.SendMailAsync(mail);
        }
    }
}