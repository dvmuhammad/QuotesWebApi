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
    public class JobFactory : IJobFactory
    {
        protected readonly IServiceScopeFactory serviceScopeFactory;

        
        public JobFactory(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var job = scope.ServiceProvider.GetService(bundle.JobDetail.JobType) as IJob;
                return job;
            }
            
        }

        public void ReturnJob(IJob job)
        {
           //Do something if need
        }
    }
}