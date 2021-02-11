using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace evolve
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // await PreExecuteAsyncInternal(stoppingToken);
            // try
            // {
            //     var cnx = new SqliteConnection(Configuration.GetConnectionString("MyDatabase"));
            //     var evolve = new Evolve.Evolve(cnx, msg => _logger.LogInformation(msg))
            //     {
            //         Locations = new[] { "db/migrations" },
            //         IsEraseDisabled = true,
            //     };

            //     evolve.Migrate();
            // }
            // catch (Exception ex)
            // {
            //     _logger.LogCritical("Database migration failed.", ex);
            //     throw;
            // }

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
