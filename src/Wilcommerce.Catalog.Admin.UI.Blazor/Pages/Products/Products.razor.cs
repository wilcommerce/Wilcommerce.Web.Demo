using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Products;
using Wilcommerce.Catalog.Admin.UI.Blazor.Services.Http;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Pages.Products
{
    public partial class Products
    {
        [Inject]
        public ProductsHttpClient Client { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        private ProductListModel products;

        private ProductListQueryModel queryModel;

        private bool loading;

        public Products()
        {
            queryModel = new ProductListQueryModel();

            loading = false;
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadProducts();
        }

        async Task ApplyProductsFilter(ProductListQueryModel model)
        {
            queryModel.ActiveOnly = model.ActiveOnly;
            queryModel.AvailableOnly = model.AvailableOnly;
            queryModel.Query = model.Query;

            await LoadProducts(queryModel);
        }

        private async Task LoadProducts(ProductListQueryModel queryModel = null)
        {
            loading = true;

            try
            {
                products = await Client.GetProducts(queryModel);
            }
            finally
            {
                StateHasChanged();
                loading = false;
            }
        }

        void OpenProductDetail(ProductListModel.ListItem product)
        {
            var url = $"catalog/products/{product.Id}";
            Navigation.NavigateTo(url);
        }

        async Task DeleteProduct(ProductListModel.ListItem product)
        {
            loading = true;

            try
            {
                await Client.DeleteProduct(product.Id);
                await LoadProducts(queryModel);
            }
            finally
            {
                loading = false;
            }
        }

        async Task RestoreProduct(ProductListModel.ListItem product)
        {
            loading = true;

            try
            {
                await Client.RestoreProduct(product.Id);
                await LoadProducts(queryModel);
            }
            finally
            {
                loading = false;
            }
        }
    }
}
