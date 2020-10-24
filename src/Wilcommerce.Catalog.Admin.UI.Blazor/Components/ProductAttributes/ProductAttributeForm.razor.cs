using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.CustomAttributes;
using Wilcommerce.Catalog.Admin.Models.ProductAttributes;
using Wilcommerce.Catalog.Admin.UI.Blazor.Services.Http;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Components.ProductAttributes
{
    public partial class ProductAttributeForm
    {
        [Inject]
        public CustomAttributesHttpClient Client { get; set; }

        [Parameter]
        public ProductAttributeModel Model { get; set; }

        [Parameter]
        public EventCallback<ProductAttributeModel> OnModelSaved { get; set; }

        EditContext context;

        IEnumerable<CustomAttributeDescriptorModel> attributes = Array.Empty<CustomAttributeDescriptorModel>();

        protected override async Task OnInitializedAsync()
        {
            attributes = await Client.SearchCustomAttributes();
        }

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
