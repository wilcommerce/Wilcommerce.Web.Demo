using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.ProductAttributes;
using Wilcommerce.Catalog.Admin.UI.Blazor.Services.Url;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Services.Http
{
    public class ProductAttributesHttpClient
    {
        public HttpClient Client { get; }

        public ProductAttributeUrlBuilder UrlBuilder { get; }

        public ProductAttributesHttpClient(HttpClient client, ProductAttributeUrlBuilder urlBuilder)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            UrlBuilder = urlBuilder ?? throw new ArgumentNullException(nameof(urlBuilder));
        }

        public async Task<IEnumerable<ProductAttributeListModel>> GetProductAttributes(Guid productId)
        {
            var url = UrlBuilder.ProductAttributeListUrl(productId);
            var attributes = await Client.GetFromJsonAsync<IEnumerable<ProductAttributeListModel>>(url);

            return attributes;
        }

        public async Task<ProductAttributeModel> GetProductAttributeDetail(Guid productId, Guid attributeId)
        {
            var url = UrlBuilder.ProductAttributeDetailUrl(productId, attributeId);
            var attribute = await Client.GetFromJsonAsync<ProductAttributeModel>(url);

            return attribute;
        }

        public async Task CreateProductAttribute(Guid productId, ProductAttributeModel model)
        {
            var url = UrlBuilder.CreateProductAttributeUrl(productId);
            var response = await Client.PostAsJsonAsync(url, model);

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Create new product attribute call ended with status code {response.StatusCode}");
            }
        }

        public async Task DeleteProductAttribute(Guid productId, Guid attributeId)
        {
            var url = UrlBuilder.DeleteProductAttributeUrl(productId, attributeId);
            var response = await Client.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Delete product attribute {attributeId} call ended with status code {response.StatusCode}");
            }
        }
    }
}
