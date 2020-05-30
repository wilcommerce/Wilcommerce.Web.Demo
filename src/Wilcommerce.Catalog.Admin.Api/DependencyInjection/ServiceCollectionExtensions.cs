using Microsoft.Extensions.DependencyInjection;
using System;
using Wilcommerce.Catalog.Admin.Api.Services;

namespace Wilcommerce.Catalog.Admin.Api
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWilcommerceCatalogAdminApi(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services
                .AddScoped<IBrandsControllerServices, BrandsControllerServices>();

            return services;
        }
    }
}
