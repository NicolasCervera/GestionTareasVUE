using back_gestion_tareas.Context;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Http.Features;

namespace backend_gestion_tareas
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue; // In case of multipart
            });

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));

            services.AddDbContext<AppDBContext>(options =>
               options.UseMySql(Configuration.GetConnectionString("MySQLConnection"), serverVersion));

            services.AddControllers();

            services.AddCors(options =>
            {
                /*
                options.AddPolicy("AllowAll",
                    builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
                */

                options.AddPolicy("AllowAll",
                    builder => {
                        builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed((Host) => true)
                        .AllowCredentials();
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IHostApplicationLifetime lifetime)
        {
            //if (lifetime.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "JWT Auth Demo V1");
                c.DocumentTitle = "WCME Aunar";
                c.RoutePrefix = string.Empty;
            });


            app.UseRouting();
            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();

        }
    }
}
