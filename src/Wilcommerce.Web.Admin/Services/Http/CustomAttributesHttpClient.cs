using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.CustomAttributes;
using Wilcommerce.Web.Admin.Services.Url;

namespace Wilcommerce.Web.Admin.Services.Http
{
    public class CustomAttributesHttpClient
    {
        public HttpClient Client { get; }

        public CustomAttributeUrlBuilder UrlBuilder { get; }

        public CustomAttributesHttpClient(HttpClient client, CustomAttributeUrlBuilder urlBuilder)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            UrlBuilder = urlBuilder ?? throw new ArgumentNullException(nameof(urlBuilder));
        }

        public async Task<CustomAttributeListModel> GetCustomAttributes(CustomAttributeListQueryModel queryModel)
        {
            var url = UrlBuilder.CustomAttributeListUrl(queryModel);

            var customAttributes = await Client.GetFromJsonAsync<CustomAttributeListModel>(url);
            return customAttributes;
        }

        public async Task<Guid> CreateNewCustomAttribute(CustomAttributeInfoModel model)
        {
            var url = UrlBuilder.CreateNewCustomAttributeUrl();

            var response = await Client.PostAsJsonAsync(url, model);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Create new custom attribute call ended with status code {response.StatusCode}");
            }

            string responseBody = await response.Content.ReadAsStringAsync();
            return Guid.Parse(responseBody);
        }

        public async Task<CustomAttributeDetailModel> GetCustomAttributeDetail(Guid attributeId)
        {
            var url = UrlBuilder.CustomAttributeDetailUrl(attributeId);

            var attribute = await Client.GetFromJsonAsync<CustomAttributeDetailModel>(url);
            return attribute;
        }

        public async Task UpdateCustomAttribute(Guid attributeId, CustomAttributeInfoModel model)
        {
            var url = UrlBuilder.UpdateCustomAttributeUrl(attributeId);

            var response = await Client.PutAsJsonAsync(url, model);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Update custom attribute {attributeId} call ended with status code {response.StatusCode}");
            }
        }

        public async Task DeleteCustomAttribute(Guid attributeId)
        {
            var url = UrlBuilder.DeleteCustomAttributeUrl(attributeId);

            var response = await Client.DeleteAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Delete custom attribute {attributeId} call ended with status code {response.StatusCode}");
            }
        }

        public async Task RestoreCustomAttribute(Guid attributeId)
        {
            var url = UrlBuilder.RestoreCustomAttributeUrl(attributeId);

            var response = await Client.PatchAsync(url, null);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Restore custom attribute {attributeId} call ended with status code {response.StatusCode}");
            }
        }
    }
}
