// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Linq;
using ExpressionPowerTools.Core.Extensions;
using ExpressionPowerTools.Serialization.EFCore.AspNetCore.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleBlazorWasm.Shared;

namespace SimpleBlazorWasm.Server
{
    /// <summary>
    /// Server startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The <see cref="IConfiguration"/>.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the <see cref="IConfiguration"/>.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940 .
        /// </summary>
        /// <param name="services">The collection of services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddDbContext<ThingContext>(options => options.UseSqlite($"Data Source=things.db"));
            CheckAndSeed(services);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/>.</param>
        /// <param name="env">The <see cref="IWebHostEnvironment"/>.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // this is all that is needed to set up a route of /efcore/ThingContext/Things for remote queries.
                endpoints.MapPowerToolsEFCore<ThingContext>();
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }

        /// <summary>
        /// Demo method for populating the database. You wouldn't do this in production.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        private void CheckAndSeed(IServiceCollection services)
        {
            var context = services.BuildServiceProvider().GetService<ThingContext>();
            if (!context.Database.EnsureCreated())
            {
                return;
            }

            var random = new Random();
            var types = GetType().Assembly.GetTypes()
                .Where(t => !t.IsAnonymousType())
                .Select(t => t.Name).Distinct().ToArray();
            string GetTypeName() => types[random.Next(types.Length)];
            var num = 100;
            while (num-- > 0)
            {
                var thing = new Thing
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = GetTypeName(),
                    Value = random.Next(),
                    IsActive = random.NextDouble() > 0.3,
                    Created = DateTime.Now.AddMinutes(-5 * random.Next(60 * 24 * 28)),
                };
                context.Things.Add(thing);
            }

            context.SaveChanges();
        }
    }
}
