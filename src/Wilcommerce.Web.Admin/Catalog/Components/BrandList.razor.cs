using Blazorise;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Brands;

namespace Wilcommerce.Web.Admin.Catalog.Components
{
    public partial class BrandList
    {
        [Inject]
        public NavigationManager Navigation { get; set; }

        [Parameter]
        public BrandListModel Brands { get; set; }

        [Parameter]
        public EventCallback<BrandListModel.ListItem> OnBrandDeleteConfirmed { get; set; }

        [Parameter]
        public EventCallback<BrandListModel.ListItem> OnBrandRestoreConfirmed { get; set; }

        private Modal confirmDeleteModal;

        private Modal confirmRestoreModal;

        private BrandListModel.ListItem selectedBrand;

        void OpenBrandDetail(BrandListModel.ListItem item)
        {
            var url = $"catalog/brands/{item.Id}";
            Navigation.NavigateTo(url);
        }

        void DeleteBrand(BrandListModel.ListItem item)
        {
            selectedBrand = item;
            confirmDeleteModal.Show();
        }

        void RestoreBrand(BrandListModel.ListItem item)
        {
            selectedBrand = item;
            confirmRestoreModal.Show();
        }

        async Task ConfirmDeleteBrand()
        {
            try
            {
                await OnBrandDeleteConfirmed.InvokeAsync(selectedBrand);
            }
            finally
            {
                selectedBrand = null;
            }
        }

        async Task ConfirmRestoreBrand()
        {
            try
            {
                await OnBrandRestoreConfirmed.InvokeAsync(selectedBrand);
            }
            finally
            {
                selectedBrand = null;
            }
        }

        void CloseModal(Modal modal) => modal.Hide();
    }
}
