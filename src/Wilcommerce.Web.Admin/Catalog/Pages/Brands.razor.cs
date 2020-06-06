using Microsoft.AspNetCore.Components;
using System;
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

        private BrandListQueryModel queryModel;

        private bool loading;

        public Brands()
        {
            queryModel = new BrandListQueryModel();
            loading = false;
        }

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

        async Task ApplyBrandsFilter(BrandListQueryModel model)
        {
            queryModel.ActiveOnly = model.ActiveOnly;
            queryModel.Query = model.Query;

            await LoadBrands(queryModel);
        }

        async Task DeleteBrand(BrandListModel.ListItem brand)
        {
            loading = true;

            try
            {
                await Client.DeleteBrand(brand.Id);
                await LoadBrands(queryModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                loading = false;
            }
        }

        async Task RestoreBrand(BrandListModel.ListItem brand)
        {
            loading = true;

            try
            {
                await Client.RestoreBrand(brand.Id);
                await LoadBrands(queryModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                loading = false;
            }
        }
    }
}
