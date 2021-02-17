using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace evolve
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            IHostBuilder host = CreateHostBuilder(args);
            await host.RunConsoleAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging => {
                    logging.AddConsole();
                })
                .UseConsoleLifetime()
                .ConfigureServices((context, services) => {
                    services.Configure<ConnectionStrings>(context.Configuration.GetSection("ConnectionStrings"));
                    services.AddHostedService<DbMigrator>();
                });
    }
}
