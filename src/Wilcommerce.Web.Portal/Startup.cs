using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wilcommerce.Catalog.Admin.Api;
using Wilcommerce.Catalog.Data.EFCore;
using Wilcommerce.Catalog.Data.EFCore.Migrations;
using Wilcommerce.Catalog.Data.EFCore.ReadModels;
using Wilcommerce.Catalog.ServiceProvider;
using Wilcommerce.Core.Data.EFCore;
using Wilcommerce.Core.Data.EFCore.Events;
using Wilcommerce.Core.Data.EFCore.Migrations;
using Wilcommerce.Core.ServiceProvider;

namespace Wilcommerce.Web.Portal
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
            services
                .AddEventsContext<EventsContext>(Configuration.GetConnectionString("Wilcommerce-Events"))
                .AddCatalogContext<CatalogContext>(Configuration.GetConnectionString("Wilcommerce-Catalog"));

            services
                .AddWilcommerceCore<EventStore>()
                .AddWilcommerceCatalog<CatalogDatabase, Catalog.Data.EFCore.Repository.Repository>();

            services
                .AddWilcommerceCatalogAdminApi();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseWilcommerceAdmin("/admin");
        }
    }
}
