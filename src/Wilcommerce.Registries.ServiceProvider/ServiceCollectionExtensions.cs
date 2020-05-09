using Microsoft.Extensions.DependencyInjection;
using System;
using Wilcommerce.Registries.Commands;
using Wilcommerce.Registries.Events.Customer;
using Wilcommerce.Registries.Events.Customer.Handlers;
using Wilcommerce.Registries.ReadModels;
using Wilcommerce.Registries.Repository;
using Wilcommerce.Registries.Services;

namespace Wilcommerce.Registries.ServiceProvider
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWilcommerceRegistries<TRegistriesDatabase, TRegistriesRepository, TAuthClient>(this IServiceCollection services)
            where TRegistriesDatabase : class, IRegistriesDatabase
            where TRegistriesRepository : class, IRepository
            where TAuthClient : class, IAuthClient
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services
                .AddWilcommerceRegistriesReadModels<TRegistriesDatabase>()
                .AddWilcommerceRegistriesRepository<TRegistriesRepository>()
                .AddWilcommerceRegistriesAuthClient<TAuthClient>()
                .AddWilcommerceRegistriesCommands()
                .AddWilcommerceRegistriesEvents();

            return services;
        }

        public static IServiceCollection AddWilcommerceRegistriesReadModels<TRegistriesDatabase>(this IServiceCollection services)
            where TRegistriesDatabase : class, IRegistriesDatabase
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services.AddScoped<IRegistriesDatabase, TRegistriesDatabase>();
        }

        public static IServiceCollection AddWilcommerceRegistriesRepository<TRegistriesRepository>(this IServiceCollection services)
            where TRegistriesRepository : class, IRepository
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services.AddScoped<IRepository, TRegistriesRepository>();
        }

        public static IServiceCollection AddWilcommerceRegistriesAuthClient<TAuthClient>(this IServiceCollection services)
            where TAuthClient : class, IAuthClient
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services.AddScoped<IAuthClient, TAuthClient>();
        }

        public static IServiceCollection AddWilcommerceRegistriesCommands(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services.AddTransient<ICustomerCommands, CustomerCommands>();
        }

        public static IServiceCollection AddWilcommerceRegistriesEvents(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            var eventBus = services.BuildServiceProvider().GetService<Core.Infrastructure.IEventBus>();

            eventBus.RegisterHandler<BillingInformationAddedEvent, BillingInfoEventHandler>();
            eventBus.RegisterHandler<BillingInformationChangedEvent, BillingInfoEventHandler>();
            eventBus.RegisterHandler<BillingInformationMarkedAsDefaultEvent, BillingInfoEventHandler>();
            eventBus.RegisterHandler<BillingoInformationRemovedEvent, BillingInfoEventHandler>();

            eventBus.RegisterHandler<CompanyInfoChangedEvent, CompanyEventHandler>();
            eventBus.RegisterHandler<CompanyLegalAddressChangedEvent, CompanyEventHandler>();
            eventBus.RegisterHandler<CompanyRegisteredEvent, CompanyEventHandler>();
            eventBus.RegisterHandler<CompanyRegisteredWithAccountEvent, CompanyEventHandler>();

            eventBus.RegisterHandler<CustomerAccountLockedEvent, CustomerEventHandler>();
            eventBus.RegisterHandler<CustomerAccountRemovedEvent, CustomerEventHandler>();
            eventBus.RegisterHandler<CustomerAccountSetEvent, CustomerEventHandler>();
            eventBus.RegisterHandler<CustomerDeletedEvent, CustomerEventHandler>();
            eventBus.RegisterHandler<CustomerRestoredEvent, CustomerEventHandler>();

            eventBus.RegisterHandler<PersonInfoChangedEvent, PersonEventHandler>();
            eventBus.RegisterHandler<PersonRegisteredEvent, PersonEventHandler>();
            eventBus.RegisterHandler<PersonRegisteredWithAccountEvent, PersonEventHandler>();

            eventBus.RegisterHandler<ShippingAddressAddedEvent, ShippingAddressEventHandler>();
            eventBus.RegisterHandler<ShippingAddressChangedEvent, ShippingAddressEventHandler>();
            eventBus.RegisterHandler<ShippingAddressMarkedAsDefaultEvent, ShippingAddressEventHandler>();
            eventBus.RegisterHandler<ShippingAddressRemovedEvent, ShippingAddressEventHandler>();

            return services;
        }
    }
}
