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
                .AddScoped<IBrandsControllerServices, BrandsControllerServices>()
                .AddScoped<ICustomAttributesControllerServices, CustomAttributesControllerServices>()
                .AddScoped<ICategoriesControllerServices, CategoriesControllerServices>()
                .AddScoped<IProductsControllerServices, ProductsControllerServices>()
                .AddScoped<IProductAttributesControllerServices, ProductAttributesControllerServices>()
                .AddScoped<IProductCategoriesControllerServices, ProductCategoriesControllerServices>()
                .AddScoped<IProductImagesControllerServices, ProductImagesControllerServices>()
                .AddScoped<IProductReviewsControllerServices, ProductReviewsControllerServices>()
                .AddScoped<IProductTierPricesControllerServices, ProductTierPricesControllerServices>();

            return services;
        }
    }
}
