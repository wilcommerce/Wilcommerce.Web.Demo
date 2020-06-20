using System;
using System.Linq;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Categories;
using Wilcommerce.Catalog.Commands;
using Wilcommerce.Catalog.ReadModels;
using Wilcommerce.Core.Common.Models;

namespace Wilcommerce.Catalog.Admin.Api.Services
{
    public class CategoriesControllerServices : ICategoriesControllerServices
    {
        public ICatalogDatabase Database { get; }

        public ICategoryCommands Commands { get; }

        public CategoriesControllerServices(ICatalogDatabase database, ICategoryCommands commands)
        {
            Database = database ?? throw new ArgumentNullException(nameof(database));
            Commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        public CategoryListModel GetCategories(CategoryListQueryModel queryModel)
        {
            if (queryModel is null)
            {
                queryModel = new CategoryListQueryModel();
            }

            var categoriesQuery = Database.Categories;
            if (queryModel.ActiveOnly)
            {
                categoriesQuery = categoriesQuery.Active();
            }
            if (queryModel.VisibleOnly)
            {
                categoriesQuery = categoriesQuery.Visible();
            }
            if (!string.IsNullOrWhiteSpace(queryModel.Query))
            {
                categoriesQuery = categoriesQuery.Where(c => c.Name.Contains(queryModel.Query) || c.Code.Contains(queryModel.Query) || c.Description.Contains(queryModel.Query));
            }

            int skip = (queryModel.Page - 1) * queryModel.Size;

            int total = categoriesQuery.Count();
            var items = categoriesQuery
                .OrderBy(c => c.Name)
                .Select(c => new CategoryListModel.ListItem
                {
                    Id = c.Id,
                    Code = c.Code,
                    Name = c.Name,
                    Url = c.Url,
                    IsVisible = c.IsVisible,
                    VisibleFrom = c.VisibleFrom,
                    VisibleTo = c.VisibleTo,
                    Deleted = c.Deleted
                }).Skip(skip).Take(queryModel.Size).ToArray();

            double pages = total / queryModel.Page;

            var model = new CategoryListModel
            {
                Total = total,
                CurrentPage = pages == 0 ? 0 : queryModel.Page,
                TotalPages = Convert.ToInt32(Math.Ceiling(pages)),
                Items = items
            };

            return model;
        }

        public async Task<Guid> CreateNewCategory(CategoryInfoModel model)
        {
            var categoryId = await Commands.CreateNewCategory(
                model.Code,
                model.Name,
                model.Url,
                model.Description,
                model.IsVisible,
                model.VisibleFrom,
                model.VisibleTo);

            return categoryId;
        }

        public CategoryDetailModel GetCategoryDetail(Guid categoryId)
        {
            var category = Database.Categories
                .SingleOrDefault(c => c.Id == categoryId);

            if (category is null)
            {
                return null;
            }

            var model = new CategoryDetailModel
            {
                Id = categoryId,
                Details = new CategoryInfoModel
                {
                    Code = category.Code,
                    Description = category.Description,
                    IsVisible = category.IsVisible,
                    Name = category.Name,
                    Url = category.Url,
                    VisibleFrom = category.VisibleFrom,
                    VisibleTo = category.VisibleTo
                },
                Seo = category.Seo,
                Parent = category.Parent is null ? null : new CategoryDetailModel.CategoryDescriptor
                {
                    Id = category.Parent.Id,
                    Code = category.Parent.Code,
                    Name = category.Parent.Name
                },
                Children = category.Children.Select(c => new CategoryDetailModel.CategoryDescriptor
                {
                    Id = c.Id,
                    Code = c.Code,
                    Name = c.Name
                }).ToList()
            };

            return model;
        }

        public async Task UpdateCategoryInfo(Guid categoryId, CategoryInfoModel model)
        {
            await Commands.UpdateCategoryInfo(
                categoryId,
                model.Code,
                model.Name,
                model.Url,
                model.Description,
                model.IsVisible,
                model.VisibleFrom,
                model.VisibleTo);
        }

        public async Task UpdateCategorySeoData(Guid categoryId, SeoData model) => await Commands.SetCategorySeoData(categoryId, model);

        public async Task AddChildToCategory(Guid categoryId, Guid childId) => await Commands.AddCategoryChild(categoryId, childId);

        public async Task AddParentCategory(Guid categoryId, Guid parentId) => await Commands.SetParentForCategory(categoryId, parentId);

        public async Task DeleteCategory(Guid categoryId) => await Commands.DeleteCategory(categoryId);

        public async Task RestoreCategory(Guid categoryId) => await Commands.RestoreCategory(categoryId);

        public async Task RemoveChildFromCategory(Guid categoryId, Guid childId) => await Commands.RemoveChildForCategory(categoryId, childId);

        public async Task RemoveParentCategory(Guid categoryId, Guid parentId) => await Commands.RemoveParentForCategory(categoryId, parentId);
    }
}
