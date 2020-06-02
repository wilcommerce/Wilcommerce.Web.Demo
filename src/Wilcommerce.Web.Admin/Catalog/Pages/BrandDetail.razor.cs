using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Brands;
using Wilcommerce.Core.Common.Models;
using Wilcommerce.Web.Admin.Services.Http;

namespace Wilcommerce.Web.Admin.Catalog.Pages
{
    public partial class BrandDetail
    {
        [Inject]
        public BrandsHttpClient Client { get; set; }

        [Parameter]
        public string BrandId { get; set; }

        Guid _BrandId => Guid.Parse(BrandId);

        private BrandDetailModel brand;

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
        }
    }
}
