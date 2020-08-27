using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        IList<ProductVariantModel> variants = new List<ProductVariantModel>();

        private bool errorRaised;

        protected override async Task OnInitializedAsync()
        {
            product = await Client.GetProductDetail(_ProductId);
            await LoadVariants();
        }

        private async Task LoadVariants()
        {
            variants = (await Client.GetProductVariants(_ProductId)).ToList();
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

        async Task UpdateProductBrand(ProductBrandModel brand)
        {
            try
            {
                await Client.UpdateProductVendor(_ProductId, brand);
                product.Brand = brand;
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

        async Task RemoveVariant(ProductVariantModel variant)
        {
            try
            {
                await Client.DeleteProductVariant(_ProductId, variant.Id);
                variants.Remove(variant);
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

        async Task SaveVariant(ProductVariantModel variant)
        {
            try
            {
                if (variant.Id == Guid.Empty)
                {
                    await Client.CreateProductVariant(_ProductId, variant);
                    await LoadVariants();
                }
                else
                {
                    await Client.UpdateProductVariant(_ProductId, variant.Id, variant);
                }
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
