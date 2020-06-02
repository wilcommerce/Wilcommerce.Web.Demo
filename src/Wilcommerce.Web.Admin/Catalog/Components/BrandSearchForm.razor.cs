using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Brands;

namespace Wilcommerce.Web.Admin.Catalog.Components
{
    public partial class BrandSearchForm
    {
        [Parameter]
        public EventCallback<BrandListQueryModel> OnBrandsFiltered { get; set; }

        BrandListQueryModel model;

        public BrandSearchForm()
        {
            model = new BrandListQueryModel();
        }

        async Task FilterBrands()
        {
            await OnBrandsFiltered.InvokeAsync(model);
        }

        async Task ClearFilters()
        {
            model = new BrandListQueryModel();
            await OnBrandsFiltered.InvokeAsync(model);
        }
    }
}
