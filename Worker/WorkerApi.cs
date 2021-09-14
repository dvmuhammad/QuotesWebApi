using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using QuotesWebApi.Controllers;
using Microsoft.EntityFrameworkCore;
using QuotesWebApi.Data;
using QuotesWebApi.Models;

namespace QuotesWebApi.Worker
{
    public class WorkerApi : IHostedService
    {
        private Timer _timer;

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(call, null, 0, 300000);

            return Task.CompletedTask;
        }

        private void call(object state)
        {
            QuotesController.quotes.RemoveAll(p => DateTime.Now.Subtract(p.DatQuote).TotalMinutes > 60);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
    }
}