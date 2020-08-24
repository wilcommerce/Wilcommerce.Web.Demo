using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Products;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Components.Products
{
    public partial class ProductSearchForm
    {
        [Parameter]
        public EventCallback<ProductListQueryModel> OnProductsFiltered { get; set; }

        [Parameter]
        public ProductListQueryModel Model { get; set; }

        async Task FilterProducts() => await OnProductsFiltered.InvokeAsync(Model);

        async Task ClearFilters()
        {
            Model = new ProductListQueryModel();
            await OnProductsFiltered.InvokeAsync(Model);
        }
    }
}
