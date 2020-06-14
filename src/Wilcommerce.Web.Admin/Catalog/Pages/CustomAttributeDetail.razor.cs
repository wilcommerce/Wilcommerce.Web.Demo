using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.CustomAttributes;
using Wilcommerce.Web.Admin.Services.Http;

namespace Wilcommerce.Web.Admin.Catalog.Pages
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
        }
    }
}
