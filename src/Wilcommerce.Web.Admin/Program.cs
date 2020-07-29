using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Wilcommerce.Catalog.Admin.UI.Blazor;
using Wilcommerce.Web.UI.Blazor;

namespace Wilcommerce.Web.Admin
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services
                .AddWilcommerceBlazorUI()
                .AddCatalogUrlBuilders()
                .AddCatalogHttpClients(new Uri(builder.HostEnvironment.BaseAddress));

            builder.RootComponents.Add<App>("app");

            var host = builder.Build();

            host.Services.UseWilcommerceBlazorUI();

            await host.RunAsync();
        }
    }
}
