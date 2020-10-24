using System;
using Wilcommerce.Web.AspNetCore.Url;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Services.Url
{
    public class ProductAttributeUrlBuilder : IUrlBuilder
    {
        public string ApiPrefix => "/api/admin/catalog";

        public string ResourceName => "products/{0}/attributes";

        public string GetResourceName(Guid productId) => string.Format(ResourceName, productId);

        public string ProductAttributeListUrl(Guid productId)
        {
            var url = $"{ApiPrefix}/{GetResourceName(productId)}";

            return url;
        }

        public string CreateProductAttributeUrl(Guid productId) => $"{ApiPrefix}/{GetResourceName(productId)}";

        public string ProductAttributeDetailUrl(Guid productId, Guid attributeId) => $"{ApiPrefix}/{GetResourceName(productId)}/{attributeId}";

        public string DeleteProductAttributeUrl(Guid productId, Guid attributeId) => $"{ApiPrefix}/{GetResourceName(productId)}/{attributeId}";
    }
}
