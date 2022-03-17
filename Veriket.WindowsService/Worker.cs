using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Veriket.WindowsService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("\n " + "Date: {time} Toshiba/Yahya", DateTimeOffset.Now
                                                                             + "\n " + "Service Name: Veriket Application Test" 
                                                                             + "\n " + "Service Description: Veriket Application Test Service");
                
                _ = File.WriteAllTextAsync((string)"C:\\ProgramData\\VeriketApp\\VeriketApp.txt",
                    (
                        "\n " + "Date:" + " " + DateTime.Now + " " + "Toshiba/Yahya"
                     + "\n " + "Service Name: Veriket Application Test"
                     + "\n " + "Service Description: Veriket Application Test Service"));
               
                await Task.Delay(1000, stoppingToken);
                
            }
        }
    }
}
