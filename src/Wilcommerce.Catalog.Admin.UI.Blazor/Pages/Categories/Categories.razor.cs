using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Categories;
using Wilcommerce.Catalog.Admin.UI.Blazor.Services.Http;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Pages.Categories
{
    public partial class Categories
    {
        [Inject]
        public CategoriesHttpClient Client { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        private CategoryListModel categories;

        private CategoryListQueryModel queryModel;

        private bool loading;

        public Categories()
        {
            queryModel = new CategoryListQueryModel();
            loading = false;
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadCategories();
        }

        async Task ApplyCategoriesFilter(CategoryListQueryModel model)
        {
            queryModel.ActiveOnly = model.ActiveOnly;
            queryModel.Query = model.Query;
            queryModel.VisibleOnly = model.VisibleOnly;

            await LoadCategories(queryModel);
        }

        async Task LoadCategories(CategoryListQueryModel queryModel = null)
        {
            loading = true;

            try
            {
                categories = await Client.GetCategories(queryModel);
            }
            finally
            {
                loading = false;
            }
        }

        void OpenCategoryDetail(CategoryListModel.ListItem category)
        {
            var url = $"catalog/categories/{category.Id}";
            Navigation.NavigateTo(url);
        }

        async Task DeleteCategory(CategoryListModel.ListItem category)
        {
            loading = true;

            try
            {
                await Client.DeleteCategory(category.Id);
                await LoadCategories(queryModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                loading = false;
            }
        }

        async Task RestoreCategory(CategoryListModel.ListItem category)
        {
            loading = true;

            try
            {
                await Client.RestoreCategory(category.Id);
                await LoadCategories(queryModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                loading = false;
            }
        }
    }
}
