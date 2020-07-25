using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Categories;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Components.Categories
{
    public partial class CategorySearchForm
    {
        [Parameter]
        public EventCallback<CategoryListQueryModel> OnCategoriesFiltered { get; set; }

        [Parameter]
        public CategoryListQueryModel Model { get; set; }

        async Task FilterCategories() => await OnCategoriesFiltered.InvokeAsync(Model);

        async Task ClearFilters()
        {
            Model = new CategoryListQueryModel();
            await OnCategoriesFiltered.InvokeAsync(Model);
        }
    }
}
