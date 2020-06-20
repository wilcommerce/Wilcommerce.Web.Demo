using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Brands;
using Wilcommerce.Catalog.Admin.UI.Blazor.Services.Http;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Pages.Brands
{
    public partial class Brands
    {
        [Inject]
        public BrandsHttpClient Client { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

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

        void OpenBrandDetail(BrandListModel.ListItem brand)
        {
            var url = $"catalog/brands/{brand.Id}";
            Navigation.NavigateTo(url);
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
