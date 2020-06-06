using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.CustomAttributes;
using Wilcommerce.Web.Admin.Services.Http;

namespace Wilcommerce.Web.Admin.Catalog.Pages
{
    public partial class CustomAttributes
    {
        [Inject]
        public CustomAttributesHttpClient Client { get; set; }

        private CustomAttributeListModel attributes;

        private CustomAttributeListQueryModel queryModel;

        private bool loading;

        public CustomAttributes()
        {
            queryModel = new CustomAttributeListQueryModel();
            loading = false;
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadCustomAttributes();
        }

        async Task LoadCustomAttributes(CustomAttributeListQueryModel queryModel = null)
        {
            loading = true;

            try
            {
                attributes = await Client.GetCustomAttributes(queryModel);
            }
            finally
            {
                loading = false;
            }
        }
    }
}
