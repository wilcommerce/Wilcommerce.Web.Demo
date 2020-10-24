using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.ProductAttributes;
using Wilcommerce.Catalog.Admin.UI.Blazor.Services.Http;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Pages.ProductAttributes
{
    public partial class ProductAttributes
    {
        [Inject]
        public ProductAttributesHttpClient Client { get; set; }

        [Parameter]
        public string ProductId { get; set; }

        Guid _ProductId => Guid.Parse(ProductId);

        IEnumerable<ProductAttributeListModel> productAttributes;

        ProductAttributeModel productAttribute = new ProductAttributeModel();

        protected override async Task OnInitializedAsync()
        {
            productAttributes = await Client.GetProductAttributes(_ProductId);
        }
    }
}
