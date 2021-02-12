using Data.FluentMigrations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMyMigrator();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "data_migrations_API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMyMigrator migrator)
        {
            var migrationConnectionStrings = new Dictionary<string, string[]>()
            {
                { Configuration.GetConnectionString(DatabaseType.Core), new[] { DatabaseType.Core } },
                { Configuration.GetConnectionString(DatabaseType.OrderLog), new [] { DatabaseType.OrderLog }},
                { Configuration.GetConnectionString(DatabaseType.OrderLog+2), new [] { DatabaseType.OrderLog }}
            };
            if (env.IsDevelopment())
            {
                foreach (var migration in migrationConnectionStrings)
                {
                    migrator.ApplyMigrations(migration.Key, migration.Value);
                }

                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "data_migrations_api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
