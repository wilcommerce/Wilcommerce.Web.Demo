using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using Wilcommerce.Catalog.Admin.UI.Blazor.Services.Http;
using Wilcommerce.Catalog.Admin.UI.Blazor.Services.Url;

namespace Wilcommerce.Catalog.Admin.UI.Blazor
{
    public static class ServiceCollectionExtensions
    {
        private static readonly Action<HttpClient, Uri> _configureHttpClient = (client, baseAddress) => client.BaseAddress = baseAddress;

        public static IServiceCollection AddCatalogUrlBuilders(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services
                .AddSingleton<BrandUrlBuilder>()
                .AddSingleton<CustomAttributeUrlBuilder>();

            return services;
        }

        public static IServiceCollection AddCatalogHttpClients(this IServiceCollection services, Uri baseAddress)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (baseAddress is null)
            {
                throw new ArgumentNullException(nameof(baseAddress));
            }

            services.AddHttpClient<BrandsHttpClient>(client => _configureHttpClient(client, baseAddress));
            services.AddHttpClient<CustomAttributesHttpClient>(client => _configureHttpClient(client, baseAddress));

            return services;
        }
    }
}
