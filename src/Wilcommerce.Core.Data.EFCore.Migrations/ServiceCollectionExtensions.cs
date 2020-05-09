using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Wilcommerce.Core.Data.EFCore.Migrations
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEventsContext<TEventsContext>(this IServiceCollection services, string connectionString)
            where TEventsContext : EventsContext
        {
            return AddEventsContext<TEventsContext>(services, connectionString, typeof(ServiceCollectionExtensions).Assembly);
        }

        public static IServiceCollection AddEventsContext<TEventsContext>(this IServiceCollection services, string connectionString, Assembly migrationAssembly)
            where TEventsContext : EventsContext
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

            services.AddDbContext<TEventsContext>(options => 
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly(assemblyName)));

            return services;
        }
    }
}
