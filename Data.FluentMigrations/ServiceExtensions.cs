using Microsoft.Extensions.DependencyInjection;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using Data.FluentMigrations.Migrations;

namespace Data.FluentMigrations
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddMigrations(this IServiceCollection services, string ConnectionString, string envName)
        {
            return services
                .Configure<RunnerOptions>(cfg => {
                    cfg.Profile = envName;
                })
                .AddFluentMigratorCore()
                .ConfigureRunner(rb =>
                    rb.AddSqlServer()
                    .WithGlobalConnectionString(ConnectionString)
                    .ScanIn(typeof(InitialMigration).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole());
        }
    }
}
