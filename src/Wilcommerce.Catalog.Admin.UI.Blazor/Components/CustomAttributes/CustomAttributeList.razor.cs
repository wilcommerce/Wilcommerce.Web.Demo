using Blazorise;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.CustomAttributes;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Components.CustomAttributes
{
    public partial class CustomAttributeList
    {
        [Parameter]
        public CustomAttributeListModel Attributes { get; set; }

        [Parameter]
        public EventCallback<CustomAttributeListModel.ListItem> OnAttributeDetailOpened { get; set; }

        [Parameter]
        public EventCallback<CustomAttributeListModel.ListItem> OnAttributeDeleteConfirmed { get; set; }

        [Parameter]
        public EventCallback<CustomAttributeListModel.ListItem> OnAttributeRestoreConfirmed { get; set; }

        async Task OpenAttributeDetail(CustomAttributeListModel.ListItem attribute) => await OnAttributeDetailOpened.InvokeAsync(attribute);

        private Modal confirmDeleteModal;

        private Modal confirmRestoreModal;

        private CustomAttributeListModel.ListItem selectedAttribute;

        void DeleteAttribute(CustomAttributeListModel.ListItem item)
        {
            selectedAttribute = item;
            confirmDeleteModal.Show();
        }

        void RestoreAttribute(CustomAttributeListModel.ListItem item)
        {
            selectedAttribute = item;
            confirmRestoreModal.Show();
        }

        async Task ConfirmDeleteAttribute()
        {
            try
            {
                await OnAttributeDeleteConfirmed.InvokeAsync(selectedAttribute);
            }
            finally
            {
                selectedAttribute = null;
            }
        }

        async Task ConfirmRestoreAttribute()
        {
            try
            {
                await OnAttributeRestoreConfirmed.InvokeAsync(selectedAttribute);
            }
            finally
            {
                selectedAttribute = null;
            }
        }

        void CloseModal(Modal modal) => modal.Hide();
    }
}
