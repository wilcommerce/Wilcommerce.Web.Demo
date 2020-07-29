using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Brands;
using Wilcommerce.Catalog.Admin.UI.Blazor.Services.Http;
using Wilcommerce.Core.Common.Models;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Pages.Brands
{
    public partial class BrandDetail
    {
        [Inject]
        public BrandsHttpClient Client { get; set; }

        [Parameter]
        public string BrandId { get; set; }

        Guid _BrandId => Guid.Parse(BrandId);

        BrandDetailModel brand;

        private bool errorRaised;

        protected override async Task OnInitializedAsync()
        {
            brand = await Client.GetBrandDetail(_BrandId);
        }

        async Task UpdateBrandInfo(BrandInfoModel model)
        {
            try
            {
                await Client.UpdateBrandInfo(_BrandId, model);
            }
            catch
            {
                errorRaised = true;
            }
            finally
            {
                StateHasChanged();
            }
        }

        async Task UpdateBrandSeoData(SeoData seo)
        {
            try
            {
                await Client.UpdateBrandSeoData(_BrandId, seo);
            }
            catch
            {
                errorRaised = true;
            }
            finally
            {
                StateHasChanged();
            }
        }
    }
}
