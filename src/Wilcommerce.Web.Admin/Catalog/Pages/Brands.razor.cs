using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Brands;
using Wilcommerce.Web.Admin.Services.Http;

namespace Wilcommerce.Web.Admin.Catalog.Pages
{
    public partial class Brands
    {
        [Inject]
        public BrandsHttpClient Client { get; set; }

        private BrandListModel brands;

        private bool loading;

        protected override async Task OnInitializedAsync()
        {
            await LoadBrands();
        }

        async Task LoadBrands(BrandListQueryModel queryModel = null)
        {
            loading = true;

            try
            {
                brands = await Client.GetBrands(queryModel);
            }
            finally
            {
                loading = false;
            }
        }

        async Task ApplyBrandsFilter(BrandListQueryModel model) => await LoadBrands(model);
    }
}
