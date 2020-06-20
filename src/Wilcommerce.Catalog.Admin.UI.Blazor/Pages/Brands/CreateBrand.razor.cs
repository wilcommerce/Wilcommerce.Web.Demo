using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Brands;
using Wilcommerce.Catalog.Admin.UI.Blazor.Services.Http;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Pages.Brands
{
    public partial class CreateBrand
    {
        [Inject]
        public BrandsHttpClient Client { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        private BrandInfoModel model = new BrandInfoModel();

        private bool errorRaised = false;

        async Task CreateNewBrand(BrandInfoModel newBrand)
        {
            try
            {
                await Client.CreateNewBrand(newBrand);
                Navigation.NavigateTo("catalog/brands");
            }
            catch
            {
                errorRaised = true;
            }
        }
    }
}
