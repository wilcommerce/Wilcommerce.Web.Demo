using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Products;
using Wilcommerce.Catalog.Admin.UI.Blazor.Services.Http;
using Wilcommerce.Core.Common.Models;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Pages.Products
{
    public partial class ProductDetail
    {
        [Inject]
        public ProductsHttpClient Client { get; set; }

        [Parameter]
        public string ProductId { get; set; }

        Guid _ProductId => Guid.Parse(ProductId);

        ProductDetailModel product;

        private bool errorRaised;

        protected override async Task OnInitializedAsync()
        {
            product = await Client.GetProductDetail(_ProductId);
        }

        async Task UpdateProductInfo(ProductInfoModel model)
        {
            try
            {
                await Client.UpdateProductInfo(_ProductId, model);
                product.Details = model;
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
        
        async Task UpdateProductSeoData(SeoData seo)
        {
            try
            {
                await Client.UpdateProductSeoData(_ProductId, seo);
                product.Seo = seo;
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
