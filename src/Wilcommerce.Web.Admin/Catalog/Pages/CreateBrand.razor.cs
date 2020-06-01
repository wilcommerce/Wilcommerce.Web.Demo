using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Brands;
using Wilcommerce.Web.Admin.Services.Http;

namespace Wilcommerce.Web.Admin.Catalog.Pages
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
