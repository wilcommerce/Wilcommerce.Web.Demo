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

        protected override async Task OnInitializedAsync()
        {
            await LoadBrands();
        }

        async Task LoadBrands(BrandListQueryModel queryModel = null)
        {
            brands = await Client.GetBrands(queryModel);
        }
    }
}
