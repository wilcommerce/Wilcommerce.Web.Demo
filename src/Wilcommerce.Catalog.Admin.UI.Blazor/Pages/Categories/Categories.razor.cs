using Microsoft.AspNetCore.Components;
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

        async Task LoadCategories()
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
    }
}
