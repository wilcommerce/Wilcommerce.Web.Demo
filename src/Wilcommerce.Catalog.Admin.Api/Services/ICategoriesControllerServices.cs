using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Categories;
using Wilcommerce.Core.Common.Models;

namespace Wilcommerce.Catalog.Admin.Api.Services
{
    public interface ICategoriesControllerServices
    {
        CategoryListModel GetCategories(CategoryListQueryModel queryModel);
        
        Task<Guid> CreateNewCategory(CategoryInfoModel model);

        CategoryDetailModel GetCategoryDetail(Guid categoryId);

        Task UpdateCategoryInfo(Guid categoryId, CategoryInfoModel model);

        Task UpdateCategorySeoData(Guid categoryId, SeoData model);

        Task AddChildToCategory(Guid categoryId, Guid childId);

        Task AddParentCategory(Guid categoryId, Guid parentId);

        Task DeleteCategory(Guid categoryId);

        Task RestoreCategory(Guid categoryId);
        
        Task RemoveChildFromCategory(Guid categoryId, Guid childId);

        Task RemoveParentCategory(Guid categoryId, Guid parentId);

        IEnumerable<CategoryDescriptorModel> SearchCategoriesByText(string query);
    }
}
