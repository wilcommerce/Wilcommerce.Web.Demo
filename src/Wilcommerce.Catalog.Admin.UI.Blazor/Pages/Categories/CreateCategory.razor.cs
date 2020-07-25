using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Categories;
using Wilcommerce.Catalog.Admin.UI.Blazor.Services.Http;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Pages.Categories
{
    public partial class CreateCategory
    {
        [Inject]
        public CategoriesHttpClient Client { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        private CategoryInfoModel model = new CategoryInfoModel();

        private bool errorRaised = false;

        async Task CreateNewCategory(CategoryInfoModel newCategory)
        {
            try
            {
                await Client.CreateCategory(newCategory);
                Navigation.NavigateTo("catalog/categories");
            }
            catch
            {
                errorRaised = true;
            }
        }
    }
}
