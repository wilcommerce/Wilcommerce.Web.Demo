using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Brands;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Components.Brands
{
    public partial class BrandSearchForm
    {
        [Parameter]
        public EventCallback<BrandListQueryModel> OnBrandsFiltered { get; set; }

        [Parameter]
        public BrandListQueryModel Model { get; set; }

        async Task FilterBrands() => await OnBrandsFiltered.InvokeAsync(Model);

        async Task ClearFilters()
        {
            Model = new BrandListQueryModel();
            await OnBrandsFiltered.InvokeAsync(Model);
        }
    }
}
