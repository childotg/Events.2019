using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InfoApp
{
    public class BackgroundWork : BackgroundService
    {
        private readonly ILogger _logger;
        public BackgroundWork(ILoggerFactory loggerFactory)
        {
            this._logger = loggerFactory.CreateLogger<BackgroundWork>();
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"Hello from {Environment.MachineName} at {DateTime.UtcNow}");
                await Task.Delay(5000);
            }
        }
    }
}
