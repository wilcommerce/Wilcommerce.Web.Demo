using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Brands;
using Wilcommerce.Core.Common.Models;
using Wilcommerce.Web.Admin.Services.Url;

namespace Wilcommerce.Web.Admin.Services.Http
{
    public class BrandsHttpClient
    {
        public HttpClient Client { get; }

        public BrandUrlBuilder UrlBuilder { get; }

        public BrandsHttpClient(HttpClient client, BrandUrlBuilder urlBuilder)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            UrlBuilder = urlBuilder ?? throw new ArgumentNullException(nameof(urlBuilder));
        }

        public async Task<BrandListModel> GetBrands(BrandListQueryModel queryModel)
        {
            var url = UrlBuilder.BrandListUrl(queryModel);

            var brands = await Client.GetFromJsonAsync<BrandListModel>(url);
            return brands;
        }

        public async Task<Guid> CreateNewBrand(BrandInfoModel model)
        {
            var url = UrlBuilder.CreateNewBrandUrl();

            var response = await Client.PostAsJsonAsync(url, model);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Create new brand call ended with status code {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();
            return Guid.Parse(content);
        }

        public async Task<BrandDetailModel> GetBrandDetail(Guid brandId)
        {
            var url = UrlBuilder.BrandDetailUrl(brandId);
            var brand = await Client.GetFromJsonAsync<BrandDetailModel>(url);

            return brand;
        }

        public async Task UpdateBrandInfo(Guid brandId, BrandInfoModel model)
        {
            var url = UrlBuilder.UpdateBrandInfoUrl(brandId);

            var response = await Client.PutAsJsonAsync(url, model);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Create new brand call ended with status code {response.StatusCode}");
            }
        }

        public async Task UpdateBrandSeoData(Guid brandId, SeoData seo)
        {
            var url = UrlBuilder.UpdateBrandSeoDataUrl(brandId);

            var response = await Client.PatchAsync(url, JsonContent.Create(seo));
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Create new brand call ended with status code {response.StatusCode}");
            }
        }

        public async Task DeleteBrand(Guid brandId)
        {
            var url = UrlBuilder.DeleteBrandUrl(brandId);

            var response = await Client.DeleteAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Create new brand call ended with status code {response.StatusCode}");
            }
        }

        public async Task RestoreBrand(Guid brandId)
        {
            var url = UrlBuilder.RestoreBrandUrl(brandId);

            var response = await Client.PatchAsync(url, null);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Create new brand call ended with status code {response.StatusCode}");
            }
        }
    }
}
