using System;
using System.Web;
using Wilcommerce.Catalog.Admin.Models.Products;
using Wilcommerce.Web.AspNetCore.Url;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Services.Url
{
    public class ProductUrlBuilder : IUrlBuilder
    {
        public string ApiPrefix => "/api/admin/catalog";

        public string ResourceName => "products";

        public string ProductsListUrl(ProductListQueryModel queryModel)
        {
            var url = $"{ApiPrefix}/{ResourceName}";
            if (queryModel != null)
            {
                url = $"{url}?activeOnly={queryModel.ActiveOnly}&page={queryModel.Page}&size={queryModel.Size}&availableOnly={queryModel.AvailableOnly}";
                if (!string.IsNullOrWhiteSpace(queryModel.Query))
                {
                    url = $"{url}&query={HttpUtility.UrlEncode(queryModel.Query)}";
                }
            }

            return url;
        }

        public string ProductDetailUrl(Guid productId) => $"{ApiPrefix}/{ResourceName}/{productId}";

        public string CreateProductUrl() => $"{ApiPrefix}/{ResourceName}";

        public string UpdateProductInfoUrl(Guid productId) => $"{ApiPrefix}/{ResourceName}/{productId}";

        public string UpdateProductSeoDataUrl(Guid productId) => $"{ApiPrefix}/{ResourceName}/{productId}/seo";

        public string DeleteProductUrl(Guid productId) => $"{ApiPrefix}/{ResourceName}/{productId}";

        public string RestoreProductUrl(Guid productId) => $"{ApiPrefix}/{ResourceName}/{productId}/restore";

        public string UpdateProductVendorUrl(Guid productId) => $"{ApiPrefix}/{ResourceName}/{productId}/vendor";

        public string GetProductVariantsUrl(Guid productId) => $"{ApiPrefix}/{ResourceName}/{productId}/variants";

        public string CreateProductVariantUrl(Guid productId) => $"{ApiPrefix}/{ResourceName}/{productId}/variants";

        public string UpdateProductVariantUrl(Guid productId, Guid variantId) => $"{ApiPrefix}/{ResourceName}/{productId}/variants/{variantId}";

        public string DeleteProductVariantUrl(Guid productId, Guid variantId) => $"{ApiPrefix}/{ResourceName}/{productId}/variants/{variantId}";
    }
}
