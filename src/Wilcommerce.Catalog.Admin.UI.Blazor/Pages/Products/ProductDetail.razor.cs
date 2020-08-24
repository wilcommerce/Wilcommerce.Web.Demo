using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Products;
using Wilcommerce.Catalog.Admin.UI.Blazor.Services.Http;

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
    }
}
