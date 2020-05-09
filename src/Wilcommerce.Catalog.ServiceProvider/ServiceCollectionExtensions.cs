using Microsoft.Extensions.DependencyInjection;
using System;
using Wilcommerce.Catalog.Commands;
using Wilcommerce.Catalog.Events.Brand;
using Wilcommerce.Catalog.Events.Brand.Handlers;
using Wilcommerce.Catalog.Events.Category;
using Wilcommerce.Catalog.Events.Category.Handlers;
using Wilcommerce.Catalog.Events.CustomAttribute;
using Wilcommerce.Catalog.Events.CustomAttribute.Handlers;
using Wilcommerce.Catalog.Events.Product;
using Wilcommerce.Catalog.Events.Product.Handlers;
using Wilcommerce.Catalog.ReadModels;
using Wilcommerce.Catalog.Repository;

namespace Wilcommerce.Catalog.ServiceProvider
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWilcommerceCatalog<TCatalogDatabase, TCatalogRepository>(this IServiceCollection services)
            where TCatalogDatabase : class, ICatalogDatabase
            where TCatalogRepository : class, IRepository
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services
                .AddWilcommerceCatalogReadModels<TCatalogDatabase>()
                .AddWilcommerceCatalogRepository<TCatalogRepository>()
                .AddWilcommerceCatalogCommands()
                .AddWilcommerceCatalogEvents();

            return services;
        }

        public static IServiceCollection AddWilcommerceCatalogReadModels<TCatalogDatabase>(this IServiceCollection services)
            where TCatalogDatabase : class, ICatalogDatabase
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services.AddScoped<ICatalogDatabase, TCatalogDatabase>();
        }

        public static IServiceCollection AddWilcommerceCatalogRepository<TCatalogRepository>(this IServiceCollection services)
            where TCatalogRepository : class, IRepository
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services.AddScoped<IRepository, TCatalogRepository>();
        }

        public static IServiceCollection AddWilcommerceCatalogCommands(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services
                .AddTransient<ICategoryCommands, CategoryCommands>()
                .AddTransient<IBrandCommands, BrandCommands>()
                .AddTransient<ICustomAttributesCommands, CustomAttributeCommands>()
                .AddTransient<IProductCommands, ProductCommands>();

            return services;
        }

        public static IServiceCollection AddWilcommerceCatalogEvents(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            var eventBus = services.BuildServiceProvider().GetService<Core.Infrastructure.IEventBus>();

            eventBus.RegisterHandler<BrandCreatedEvent, BrandEventHandler>();
            eventBus.RegisterHandler<BrandDeletedEvent, BrandEventHandler>();
            eventBus.RegisterHandler<BrandInfoUpdatedEvent, BrandEventHandler>();
            eventBus.RegisterHandler<BrandRestoredEvent, BrandEventHandler>();

            eventBus.RegisterHandler<CategoryChildAddedEvent, CategoryEventHandler>();
            eventBus.RegisterHandler<CategoryChildRemovedEvent, CategoryEventHandler>();
            eventBus.RegisterHandler<CategoryCreatedEvent, CategoryEventHandler>();
            eventBus.RegisterHandler<CategoryDeletedEvent, CategoryEventHandler>();
            eventBus.RegisterHandler<CategoryInfoUpdatedEvent, CategoryEventHandler>();
            eventBus.RegisterHandler<CategoryRestoredEvent, CategoryEventHandler>();

            eventBus.RegisterHandler<CustomAttributeCreatedEvent, CustomAttributeEventHandler>();
            eventBus.RegisterHandler<CustomAttributeDeletedEvent, CustomAttributeEventHandler>();
            eventBus.RegisterHandler<CustomAttributeRestoredEvent, CustomAttributeEventHandler>();
            eventBus.RegisterHandler<CustomAttributeUpdatedEvent, CustomAttributeEventHandler>();

            eventBus.RegisterHandler<ProductAttributeAddedEvent, ProductEventHandler>();
            eventBus.RegisterHandler<ProductAttributeRemovedEvent, ProductEventHandler>();
            eventBus.RegisterHandler<ProductCategoryAddedEvent, ProductEventHandler>();
            eventBus.RegisterHandler<ProductCategoryRemovedEvent, ProductEventHandler>();
            eventBus.RegisterHandler<ProductCreatedEvent, ProductEventHandler>();
            eventBus.RegisterHandler<ProductDeletedEvent, ProductEventHandler>();
            eventBus.RegisterHandler<ProductImageAddedEvent, ProductEventHandler>();
            eventBus.RegisterHandler<ProductImageRemovedEvent, ProductEventHandler>();
            eventBus.RegisterHandler<ProductInfoUpdateEvent, ProductEventHandler>();
            eventBus.RegisterHandler<ProductMainCategoryChangedEvent, ProductEventHandler>();
            eventBus.RegisterHandler<ProductRestoredEvent, ProductEventHandler>();
            eventBus.RegisterHandler<ProductReviewAddedEvent, ProductEventHandler>();
            eventBus.RegisterHandler<ProductReviewApprovedEvent, ProductEventHandler>();
            eventBus.RegisterHandler<ProductReviewRemovedEvent, ProductEventHandler>();
            eventBus.RegisterHandler<ProductTierPriceAddedEvent, ProductEventHandler>();
            eventBus.RegisterHandler<ProductTierPriceChangedEvent, ProductEventHandler>();
            eventBus.RegisterHandler<ProductTierPriceRemovedEvent, ProductEventHandler>();
            eventBus.RegisterHandler<ProductVariantAddedEvent, ProductEventHandler>();
            eventBus.RegisterHandler<ProductVariantChangedEvent, ProductEventHandler>();
            eventBus.RegisterHandler<ProductVariantRemovedEvent, ProductEventHandler>();
            eventBus.RegisterHandler<ProductVendorSetEvent, ProductEventHandler>();

            return services;
        }
    }
}
