using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using Wilcommerce.Web.Admin.Services.Http;
using Wilcommerce.Web.Admin.Services.Url;

namespace Wilcommerce.Web.Admin
{
    public static class ServiceCollectionExtensions
    {
        private static readonly Action<HttpClient, Uri> _configureHttpClient = (client, baseAddress) => client.BaseAddress = baseAddress;

        public static IServiceCollection AddUrlBuilders(this IServiceCollection services)
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
