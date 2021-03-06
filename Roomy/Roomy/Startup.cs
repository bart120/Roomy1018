﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Roomy.Data;

namespace Roomy
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);

            this.Configuration = builder.Build();
            Debug.WriteLine(this.Configuration.GetConnectionString("DefaultConnection"));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession(options =>
                options.IdleTimeout = TimeSpan.FromMinutes(5));

            services.AddMvc();

            services.AddDbContext<RoomyDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /*app.Use(async (context, next) =>
            {
                var statusCode = context.Request.Query["statuscode"];
                Debug.WriteLine($"CODE: {statusCode}");
                if (!string.IsNullOrWhiteSpace(statusCode))
                {
                    await Task.FromResult(0);
                }
                else
                {
                    context.Response.StatusCode = 305;
                    await next();
                }
            });*/

            app.UseStaticFiles();

            app.UseSession();

            //app.UseMvcWithDefaultRoute();
            app.UseMvc(ConfigureRoute);

            /*app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });*/
        }

        private void ConfigureRoute(IRouteBuilder routeBuilder)
        {
            /*routeBuilder.MapRoute(
                name: "apropos",
                template: "a-propos-de",
                defaults: new { controller = "Home", action = "About" });*/
            routeBuilder.MapRoute(
                name: "areas",
                template: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
            );

            routeBuilder.MapRoute(
                name: "Default",
                template: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
