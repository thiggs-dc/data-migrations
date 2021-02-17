using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace evolve
{
    public class DbMigrator : BackgroundService
    {
        private readonly ILogger<DbMigrator> _logger;
        private readonly string _connectionString;

        public DbMigrator(ILogger<DbMigrator> logger, IOptions<ConnectionStrings> options)
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
                    Placeholders = new Dictionary<string, string>
                    {
                        ["${orderTable}"] = "OrderTable1"
                    }
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
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
