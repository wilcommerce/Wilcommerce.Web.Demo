using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.CustomAttributes;
using Wilcommerce.Catalog.Admin.UI.Blazor.Services.Http;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Pages.CustomAttributes
{
    public partial class CustomAttributeDetail
    {
        [Inject]
        public CustomAttributesHttpClient Client { get; set; }

        [Parameter]
        public string AttributeId { get; set; }

        Guid _AttributeId => Guid.Parse(AttributeId);

        CustomAttributeDetailModel customAttribute;

        private bool errorRaised;

        protected override async Task OnInitializedAsync()
        {
            customAttribute = await Client.GetCustomAttributeDetail(_AttributeId);
        }

        async Task UpdateCustomAttribute(CustomAttributeInfoModel model)
        {
            try
            {
                await Client.UpdateCustomAttribute(_AttributeId, model);
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
