using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using Wilcommerce.Catalog.Admin.Models.ProductAttributes;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Components.ProductAttributes
{
    public partial class ProductAttributeList
    {
        [Parameter]
        public IEnumerable<ProductAttributeListModel> Attributes { get; set; }

        [Parameter]
        public EventCallback<ProductAttributeListModel> OnAttributeDeleteConfirmed { get; set; }
    }
}
