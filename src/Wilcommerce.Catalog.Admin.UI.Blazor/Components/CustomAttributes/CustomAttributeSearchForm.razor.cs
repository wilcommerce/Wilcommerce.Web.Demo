using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.CustomAttributes;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Components.CustomAttributes
{
    public partial class CustomAttributeSearchForm
    {
        [Parameter]
        public CustomAttributeListQueryModel Model { get; set; }

        [Parameter]
        public EventCallback<CustomAttributeListQueryModel> OnCustomAttributesFiltered { get; set; }

        async Task FilterAttributes() => await OnCustomAttributesFiltered.InvokeAsync(Model);

        async Task ClearFilters()
        {
            Model = new CustomAttributeListQueryModel();
            await OnCustomAttributesFiltered.InvokeAsync(Model);
        }
    }
}
