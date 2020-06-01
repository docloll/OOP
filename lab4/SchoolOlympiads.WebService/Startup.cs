using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchoolOlympiads.DomainObjects;
using SchoolOlympiads.DomainObjects.Ports;
using SchoolOlympiads.ApplicationServices.GetOlympiadListUseCase;
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
            services.AddScoped<InMemoryOlympiadRepository>(x => new InMemoryOlympiadRepository(
                new List<Olympiad>()
                {
                    new Olympiad()
                    {
                    Id = 1,
                    Name = "Всероссийская олимпиада по технологии",
                    Subject = "Технология ",
                    Type = "Всероссийская олимпиада",
                    Class = "7 - 11",
                    Year = 2015
                    },
                    new Olympiad()
                    {
                    Id = 2,
                    Name = "Математический праздник",
                    Subject = "Математика",
                    Type = "Московская олимпиада",
                    Class = "6 - 7",
                    Year = 2016
                    },
                    new Olympiad()
                    {
                    Id = 3,
                    Name = "Московская астрономическая олимпиада",
                    Subject = "Астрономия",
                    Type = "Московская олимпиада",
                    Class = "5 - 11",
                    Year = 2016
                    }
             }));
            services.AddScoped<IReadOnlyOlympiadRepository>(x => x.GetRequiredService<InMemoryOlympiadRepository>());
            services.AddScoped<IOlympiadRepository>(x => x.GetRequiredService<InMemoryOlympiadRepository>());

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
