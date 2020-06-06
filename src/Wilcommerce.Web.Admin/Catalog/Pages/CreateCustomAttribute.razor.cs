﻿using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.CustomAttributes;
using Wilcommerce.Web.Admin.Services.Http;

namespace Wilcommerce.Web.Admin.Catalog.Pages
{
    public partial class CreateCustomAttribute
    {
        [Inject]
        public CustomAttributesHttpClient Client { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        private CustomAttributeInfoModel model = new CustomAttributeInfoModel();

        private bool errorRaised = false;

        async Task CreateNewCustomAttribute(CustomAttributeInfoModel newAttribute)
        {
            try
            {
                await Client.CreateNewCustomAttribute(newAttribute);
                Navigation.NavigateTo("catalog/customattributes");
            }
            catch
            {
                errorRaised = true;
            }
        }
    }
}
