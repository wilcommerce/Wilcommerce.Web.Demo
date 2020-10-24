using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.ProductAttributes;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Components.ProductAttributes
{
    public partial class ProductAttributeForm
    {
        [Parameter]
        public ProductAttributeModel Model { get; set; }

        [Parameter]
        public EventCallback<ProductAttributeModel> OnModelSaved { get; set; }

        EditContext context;

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            context = new EditContext(Model);
        }

        async Task HandleSubmit() => await OnModelSaved.InvokeAsync(Model);

        void Clear()
        {
            Model = new ProductAttributeModel();
            StateHasChanged();
        }
    }
}
