using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
