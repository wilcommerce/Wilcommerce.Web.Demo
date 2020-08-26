using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Brands;
using Wilcommerce.Catalog.Admin.UI.Blazor.Services.Url;
using Wilcommerce.Core.Common.Models;
using Wilcommerce.Web.AspNetCore.Http;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Services.Http
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

        public async Task CreateNewBrand(BrandInfoModel model)
        {
            var url = UrlBuilder.CreateNewBrandUrl();

            var requestContent = new MultipartFormDataContent();
            requestContent.Add(new StringContent(model.Name), "name");
            requestContent.Add(new StringContent(model.Url), "url");
            if (!string.IsNullOrWhiteSpace(model.Description))
            {
                requestContent.Add(new StringContent(model.Description), "description");
            }
            if (model.Image != null)
            {
                var imageContent = new ByteArrayContent(model.Image.ToByteArray());
                imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse(model.Image.ContentType);

                requestContent.Add(imageContent, "image", model.Image.FileName);
            }

            var response = await Client.PostAsync(url, requestContent);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Create new brand call ended with status code {response.StatusCode}");
            }
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

            var requestContent = new MultipartFormDataContent();
            requestContent.Add(new StringContent(model.Name), "name");
            requestContent.Add(new StringContent(model.Url), "url");
            if (!string.IsNullOrWhiteSpace(model.Description))
            {
                requestContent.Add(new StringContent(model.Description), "description");
            }
            if (model.Image != null)
            {
                var imageContent = new ByteArrayContent(model.Image.ToByteArray());
                imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse(model.Image.ContentType);

                requestContent.Add(imageContent, "image", model.Image.FileName);
            }

            var response = await Client.PutAsync(url, requestContent);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Update brand {brandId} call ended with status code {response.StatusCode}");
            }
        }

        public async Task UpdateBrandSeoData(Guid brandId, SeoData seo)
        {
            var url = UrlBuilder.UpdateBrandSeoDataUrl(brandId);

            var response = await Client.PatchAsync(url, JsonContent.Create(seo));
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Update brand {brandId} seo info call ended with status code {response.StatusCode}");
            }
        }

        public async Task DeleteBrand(Guid brandId)
        {
            var url = UrlBuilder.DeleteBrandUrl(brandId);

            var response = await Client.DeleteAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Delete brand {brandId} call ended with status code {response.StatusCode}");
            }
        }

        public async Task RestoreBrand(Guid brandId)
        {
            var url = UrlBuilder.RestoreBrandUrl(brandId);

            var response = await Client.PatchAsync(url, null);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Restore brand {brandId} call ended with status code {response.StatusCode}");
            }
        }

        public async Task<IEnumerable<BrandDescriptorModel>> SearchBrandsByText(string query)
        {
            var url = UrlBuilder.SearchBrandByTextUrl(query);
            var brands = await Client.GetFromJsonAsync<IEnumerable<BrandDescriptorModel>>(url);

            return brands;
        }
    }
}
