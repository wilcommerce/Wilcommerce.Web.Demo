using System;
using Wilcommerce.Catalog.Admin.Models.Categories;
using Wilcommerce.Web.AspNetCore.Url;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Services.Url
{
    public class CategoryUrlBuilder : IUrlBuilder
    {
        public string ApiPrefix => "/api/admin/catalog";

        public string ResourceName => "categories";

        public string CategoriesListUrl(CategoryListQueryModel queryModel)
        {
            var url = $"{ApiPrefix}/{ResourceName}";
            if (queryModel != null)
            {
                url = $"{url}?activeOnly={queryModel.ActiveOnly}&page={queryModel.Page}&size={queryModel.Size}&visibleOnly={queryModel.VisibleOnly}";
                if (!string.IsNullOrWhiteSpace(queryModel.Query))
                {
                    url = $"{url}&query={queryModel.Query}";
                }
            }

            return url;
        }

        public string CategoryDetailUrl(Guid categoryId) => $"{ApiPrefix}/{ResourceName}/{categoryId}";

        public string CreateCategoryUrl() => $"{ApiPrefix}/{ResourceName}";

        public string UpdateCategoryInfoUrl(Guid categoryId) => $"{ApiPrefix}/{ResourceName}/{categoryId}";

        public string UpdateCategorySeoDataUrl(Guid categoryId) => $"{ApiPrefix}/{ResourceName}/{categoryId}/seo";

        public string AddCategoryChildUrl(Guid categoryId, Guid childId) => $"{ApiPrefix}/{ResourceName}/{categoryId}/child/{childId}";

        public string AddCategoryParentUrl(Guid categoryId, Guid parentId) => $"{ApiPrefix}/{ResourceName}/{categoryId}/parent/{parentId}";

        public string DeleteCategoryUrl(Guid categoryId) => $"{ApiPrefix}/{ResourceName}/{categoryId}";

        public string RestoreCategoryUrl(Guid categoryId) => $"{ApiPrefix}/{ResourceName}/{categoryId}/restore";

        public string DeleteCategoryChildUrl(Guid categoryId, Guid childId) => $"{ApiPrefix}/{ResourceName}/{categoryId}/child/{childId}";

        public string DeleteCategoryParentUrl(Guid categoryId, Guid parentId) => $"{ApiPrefix}/{ResourceName}/{categoryId}/parent/{parentId}";
    }
}
