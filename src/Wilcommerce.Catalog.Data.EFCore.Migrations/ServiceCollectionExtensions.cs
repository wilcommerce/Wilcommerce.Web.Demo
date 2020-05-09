using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Wilcommerce.Catalog.Data.EFCore.Migrations
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCatalogContext<TCatalogContext>(this IServiceCollection services, string connectionString)
            where TCatalogContext : CatalogContext
        {
            return AddCatalogContext<TCatalogContext>(services, connectionString, typeof(ServiceCollectionExtensions).Assembly);
        }

        public static IServiceCollection AddCatalogContext<TCatalogContext>(this IServiceCollection services, string connectionString, Assembly migrationAssembly)
            where TCatalogContext : CatalogContext
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException("value cannot be empty", nameof(connectionString));
            }

            string assemblyName = migrationAssembly.GetName().Name;

            services.AddDbContext<TCatalogContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly(assemblyName)));

            return services;
        }
    }
}
