using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Categories;
using Wilcommerce.Catalog.Admin.UI.Blazor.Services.Http;
using Wilcommerce.Core.Common.Models;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Pages.Categories
{
    public partial class CategoryDetail
    {
        [Inject]
        public CategoriesHttpClient Client { get; set; }

        [Parameter]
        public string CategoryId { get; set; }

        Guid _CategoryId => Guid.Parse(CategoryId);

        CategoryDetailModel category;

        private bool errorRaised;

        protected override async Task OnInitializedAsync()
        {
            category = await Client.GetCategoryDetail(_CategoryId);
        }

        async Task UpdateCategoryInfo(CategoryInfoModel model)
        {
            try
            {
                await Client.UpdateCategoryInfo(_CategoryId, model);
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

        async Task UpdateCategorySeoData(SeoData seo)
        {
            try
            {
                await Client.UpdateCategorySeoData(_CategoryId, seo);
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
