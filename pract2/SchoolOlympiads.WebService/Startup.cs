using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchoolOlympiads.DomainObjects;
using SchoolOlympiads.DomainObjects.Ports;
using SchoolOlympiads.ApplicationServices.GetOlympiadListUseCase;
using SchoolOlympiads.ApplicationServices.Ports.Gateways.Database;
using SchoolOlympiads.InfrastructureServices.Gateways.Database;
using Microsoft.EntityFrameworkCore;
using SchoolOlympiads.ApplicationServices.Repositories;
using System.Collections.Generic;

namespace SchoolOlympiads.WebService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddDbContext<OlympiadContext>(opts =>
                opts.UseSqlite($"Filename={System.IO.Path.Combine(System.Environment.CurrentDirectory, "SchoolOlympiads.db")}")
            );

            services.AddScoped<IOlympiadDatabaseGateway, OlympiadEFSqliteGateway>();

            services.AddScoped<DbOlympiadRepository>();
            services.AddScoped<IReadOnlyOlympiadRepository>(x => x.GetRequiredService<DbOlympiadRepository>());
            services.AddScoped<IOlympiadRepository>(x => x.GetRequiredService<DbOlympiadRepository>());

            services.AddScoped<IGetOlympiadListUseCase, GetOlympiadListUseCase>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
