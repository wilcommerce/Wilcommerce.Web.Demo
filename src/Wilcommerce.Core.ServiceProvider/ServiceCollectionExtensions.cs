using Microsoft.Extensions.DependencyInjection;
using System;
using Wilcommerce.Core.Infrastructure;
using Wilcommerce.Core.ServiceProvider.Events;

namespace Wilcommerce.Core.ServiceProvider
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWilcommerceCore<TEventStore, TEventBus>(this IServiceCollection services, TEventBus eventBus)
            where TEventStore : class, IEventStore
            where TEventBus : class, IEventBus
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (eventBus is null)
            {
                throw new ArgumentNullException(nameof(eventBus));
            }

            services
                .AddEventStore<TEventStore>()
                .AddEventBus(eventBus);

            return services;
        }

        public static IServiceCollection AddWilcommerceCore<TEventStore>(this IServiceCollection services)
            where TEventStore : class, IEventStore
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services.AddWilcommerceCore<TEventStore, InMemoryEventBus>(new InMemoryEventBus(services));
        }

        public static IServiceCollection AddEventStore<TEventStore>(this IServiceCollection services)
            where TEventStore : class, IEventStore
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services.AddScoped<IEventStore, TEventStore>();
        }

        public static IServiceCollection AddEventBus<TEventBus>(this IServiceCollection services, TEventBus eventBus)
            where TEventBus : class, IEventBus
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (eventBus is null)
            {
                throw new ArgumentNullException(nameof(eventBus));
            }

            return services.AddSingleton<IEventBus>(eventBus);
        }
    }
}
