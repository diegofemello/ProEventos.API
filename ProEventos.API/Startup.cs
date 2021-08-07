using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProEventos.Repository;
using ProEventos.Repository.Contexts;
using ProEventos.Repository.Interfaces;
using ProEventos.Service;
using ProEventos.Sevice.Interfaces;

namespace ProEventos.API
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
            // var connection = Configuration["MySQLConnection:MySQLConnectionString"];
            var connection = Configuration.GetConnectionString("Default");
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 25));

            services.AddDbContext<ProEventosContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(connection, serverVersion)
            );

            services.AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings
                    .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddScoped<IEventoService, EventoService>();
            services.AddScoped<IGeralRepository, GeralRepository>();
            services.AddScoped<IEventoRepository, EventoRepository>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProEventos.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProEventos.API v1"));
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
