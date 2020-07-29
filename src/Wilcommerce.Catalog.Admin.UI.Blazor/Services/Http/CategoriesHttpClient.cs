using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Categories;
using Wilcommerce.Catalog.Admin.UI.Blazor.Services.Url;
using Wilcommerce.Core.Common.Models;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Services.Http
{
    public class CategoriesHttpClient
    {
        public HttpClient Client { get; }
        
        public CategoryUrlBuilder UrlBuilder { get; }

        public CategoriesHttpClient(HttpClient client, CategoryUrlBuilder urlBuilder)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            UrlBuilder = urlBuilder ?? throw new ArgumentNullException(nameof(urlBuilder));
        }

        public async Task<CategoryListModel> GetCategories(CategoryListQueryModel queryModel)
        {
            var url = UrlBuilder.CategoriesListUrl(queryModel);

            var categories = await Client.GetFromJsonAsync<CategoryListModel>(url);
            return categories;
        }

        public async Task<CategoryDetailModel> GetCategoryDetail(Guid categoryId)
        {
            var url = UrlBuilder.CategoryDetailUrl(categoryId);

            var category = await Client.GetFromJsonAsync<CategoryDetailModel>(url);
            return category;
        }

        public async Task CreateCategory(CategoryInfoModel model)
        {
            var url = UrlBuilder.CreateCategoryUrl();

            var response = await Client.PostAsJsonAsync(url, model);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Create new category call ended with status code {response.StatusCode}");
            }
        }

        public async Task UpdateCategoryInfo(Guid categoryId, CategoryInfoModel model)
        {
            var url = UrlBuilder.UpdateCategoryInfoUrl(categoryId);

            var response = await Client.PutAsJsonAsync(url, model);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Update category {categoryId} call ended with status code {response.StatusCode}");
            }
        }

        public async Task UpdateCategorySeoData(Guid categoryId, SeoData seo)
        {
            var url = UrlBuilder.UpdateCategorySeoDataUrl(categoryId);

            var response = await Client.PatchAsync(url, JsonContent.Create(seo));
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Update category {categoryId} seo info call ended with status code {response.StatusCode}");
            }
        }

        public async Task AddCategoryChild(Guid categoryId, Guid childId)
        {
            var url = UrlBuilder.AddCategoryChildUrl(categoryId, childId);

            var response = await Client.PatchAsync(url, null);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Add child {childId} to category {categoryId} call ended with status code {response.StatusCode}");
            }
        }

        public async Task AddCategoryParent(Guid categoryId, Guid parentId)
        {
            var url = UrlBuilder.AddCategoryParentUrl(categoryId, parentId);

            var response = await Client.PatchAsync(url, null);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Add parent {parentId} to category {categoryId} call ended with status code {response.StatusCode}");
            }
        }

        public async Task DeleteCategory(Guid categoryId)
        {
            var url = UrlBuilder.DeleteCategoryUrl(categoryId);

            var response = await Client.DeleteAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Delete category {categoryId} call ended with status code {response.StatusCode}");
            }
        }

        public async Task RestoreCategory(Guid categoryId)
        {
            var url = UrlBuilder.RestoreCategoryUrl(categoryId);

            var response = await Client.PatchAsync(url, null);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Restore category {categoryId} call ended with status code {response.StatusCode}");
            }
        }

        public async Task DeleteCategoryChild(Guid categoryId, Guid childId)
        {
            var url = UrlBuilder.DeleteCategoryChildUrl(categoryId, childId);

            var response = await Client.DeleteAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Delete child {childId} from category {categoryId} call ended with status code {response.StatusCode}");
            }
        }

        public async Task DeleteCategoryParent(Guid categoryId, Guid parentId)
        {
            var url = UrlBuilder.DeleteCategoryParentUrl(categoryId, parentId);

            var response = await Client.DeleteAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Delete parent {parentId} from category {categoryId} call ended with status code {response.StatusCode}");
            }
        }

        public async Task<IEnumerable<CategoryDescriptorModel>> SearchCategoriesByText(string query)
        {
            var url = UrlBuilder.SearchCategoriesByTextUrl(query);

            var categories = await Client.GetFromJsonAsync<IEnumerable<CategoryDescriptorModel>>(url);
            return categories;
        }
    }
}
