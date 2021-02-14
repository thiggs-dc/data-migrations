using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace evolve
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly string _connectionString;

        public Worker(ILogger<Worker> logger, IOptions<ConnectionStrings> options)
        {
            _logger = logger;
            _connectionString = options.Value.EvolveDb;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                var cnx = new System.Data.SqlClient.SqlConnection(_connectionString);
                var evolve = new Evolve.Evolve(cnx, msg => _logger.LogInformation(msg))
                {
                    Locations = new[] { "migrations", "views" },
                    IsEraseDisabled = true,
                };
                evolve.Migrate();
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Database migration failed.", ex);
                throw;
            }

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
