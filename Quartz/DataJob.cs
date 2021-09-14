using Microsoft.Extensions.Logging;
using Quartz;
using System.Threading.Tasks;
using QuotesWebApi.Worker;
using QuotesWebApi.Quartz;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Quartz.Impl;
using Quartz.Spi;


namespace QuotesWebApi.Quartz
{
    public class DataJob : IJob
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<DataJob> _logger;

        public DataJob(IServiceScopeFactory serviceScopeFactory, ILogger<DataJob> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var emailsender = scope.ServiceProvider.GetService<IEmailSender>();
                _logger.Log(LogLevel.Information, "Executed sending quotes");
                await emailsender.SendEmailAsync("example@gmail.com", "example", "hello");
            }
        }
    }
}