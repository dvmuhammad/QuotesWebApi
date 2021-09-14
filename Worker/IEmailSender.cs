using Microsoft.Extensions.Logging;
using Quartz;
using System.Threading.Tasks;
using QuotesWebApi.Worker;
using QuotesWebApi.Quartz;

namespace QuotesWebApi.Worker
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}