using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.CustomAttributes;
using Wilcommerce.Web.Admin.Services.Http;

namespace Wilcommerce.Web.Admin.Catalog.Pages
{
    public partial class CustomAttributes
    {
        [Inject]
        public CustomAttributesHttpClient Client { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

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

        async Task ApplyAttributesFilter(CustomAttributeListQueryModel model)
        {
            queryModel.ActiveOnly = model.ActiveOnly;
            queryModel.Query = model.Query;

            await LoadCustomAttributes(queryModel);
        }

        void OpenAttributeDetail(CustomAttributeListModel.ListItem attribute)
        {
            var url = $"catalog/customattributes/{attribute.Id}";
            Navigation.NavigateTo(url);
        }

        async Task DeleteAttribute(CustomAttributeListModel.ListItem attribute)
        {
            loading = true;

            try
            {
                await Client.DeleteCustomAttribute(attribute.Id);
                await LoadCustomAttributes(queryModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                loading = false;
            }
        }

        async Task RestoreAttribute(CustomAttributeListModel.ListItem attribute)
        {
            loading = true;

            try
            {
                await Client.RestoreCustomAttribute(attribute.Id);
                await LoadCustomAttributes(queryModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                loading = false;
            }
        }
    }
}
