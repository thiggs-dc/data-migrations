using Microsoft.Extensions.DependencyInjection;

namespace Data.FluentMigrations
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddMyMigrator(this IServiceCollection services)
        {
            return services
                .AddSingleton<IMyMigrator, MyMigrator>();
        }
    }
}
