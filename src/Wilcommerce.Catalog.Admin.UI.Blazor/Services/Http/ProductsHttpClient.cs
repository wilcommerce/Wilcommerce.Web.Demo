using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Products;
using Wilcommerce.Catalog.Admin.UI.Blazor.Services.Url;
using Wilcommerce.Core.Common.Models;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Services.Http
{
    public class ProductsHttpClient
    {
        public HttpClient Client { get; }
        
        public ProductUrlBuilder UrlBuilder { get; }

        public ProductsHttpClient(HttpClient client, ProductUrlBuilder urlBuilder)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            UrlBuilder = urlBuilder ?? throw new ArgumentNullException(nameof(urlBuilder));
        }

        public async Task<ProductListModel> GetProducts(ProductListQueryModel queryModel)
        {
            var url = UrlBuilder.ProductsListUrl(queryModel);

            var products = await Client.GetFromJsonAsync<ProductListModel>(url);
            return products;
        }

        public async Task<ProductDetailModel> GetProductDetail(Guid productId)
        {
            var url = UrlBuilder.ProductDetailUrl(productId);

            var product = await Client.GetFromJsonAsync<ProductDetailModel>(url);
            return product;
        }

        public async Task CreateProduct(ProductInfoModel model)
        {
            var url = UrlBuilder.CreateProductUrl();

            var response = await Client.PostAsJsonAsync(url, model);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Create new product call ended with status code {response.StatusCode}");
            }
        }

        public async Task UpdateProductInfo(Guid productId, ProductInfoModel model)
        {
            var url = UrlBuilder.UpdateProductInfoUrl(productId);

            var response = await Client.PutAsJsonAsync(url, model);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Update product {productId} call ended with status code {response.StatusCode}");
            }
        }

        public async Task UpdateProductSeoData(Guid productId, SeoData seo)
        {
            var url = UrlBuilder.UpdateProductSeoDataUrl(productId);

            var response = await Client.PatchAsync(url, JsonContent.Create(seo));
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Update product {productId} seo info call ended with status code {response.StatusCode}");
            }
        }

        public async Task DeleteProduct(Guid productId)
        {
            var url = UrlBuilder.DeleteProductUrl(productId);

            var response = await Client.DeleteAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Delete product {productId} call ended with status code {response.StatusCode}");
            }
        }

        public async Task RestoreProduct(Guid productId)
        {
            var url = UrlBuilder.RestoreProductUrl(productId);

            var response = await Client.PatchAsync(url, null);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Restore product {productId} call ended with status code {response.StatusCode}");
            }
        }

        public async Task UpdateProductVendor(Guid productId, ProductBrandModel brand)
        {
            var url = UrlBuilder.UpdateProductVendorUrl(productId);

            var response = await Client.PatchAsync(url, JsonContent.Create(brand));
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Update product {productId} vendor {brand.Name} call ended with status code {response.StatusCode}");
            }
        }

        public async Task<IEnumerable<ProductVariantModel>> GetProductVariants(Guid productId)
        {
            var url = UrlBuilder.GetProductVariantsUrl(productId);

            var variants = await Client.GetFromJsonAsync<IEnumerable<ProductVariantModel>>(url);
            return variants;
        }

        public async Task CreateProductVariant(Guid productId, ProductVariantModel variant)
        {
            var url = UrlBuilder.CreateProductVariantUrl(productId);

            var response = await Client.PostAsJsonAsync(url, variant);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Create variant {variant.Name} for product {productId} call ended with status code {response.StatusCode}");
            }
        }

        public async Task UpdateProductVariant(Guid productId, Guid variantId, ProductVariantModel variant)
        {
            var url = UrlBuilder.UpdateProductVariantUrl(productId, variantId);

            var response = await Client.PutAsJsonAsync(url, variant);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Update variant {variantId} for product {productId} call ended with status code {response.StatusCode}");
            }
        }

        public async Task DeleteProductVariant(Guid productId, Guid variantId)
        {
            var url = UrlBuilder.DeleteProductVariantUrl(productId, variantId);

            var response = await Client.DeleteAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Delete variant {variantId} for product {productId} call ended with status code {response.StatusCode}");
            }
        }
    }
}
