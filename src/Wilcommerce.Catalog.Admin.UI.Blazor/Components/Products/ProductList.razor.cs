using Blazorise;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Products;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Components.Products
{
    public partial class ProductList
    {
        [Parameter]
        public ProductListModel Products { get; set; }

        [Parameter]
        public EventCallback<ProductListModel.ListItem> OnProductDetailOpened { get; set; }

        [Parameter]
        public EventCallback<ProductListModel.ListItem> OnProductDeleteConfirmed { get; set; }

        [Parameter]
        public EventCallback<ProductListModel.ListItem> OnProductRestoreConfirmed { get; set; }

        private Modal confirmDeleteModal;

        private Modal confirmRestoreModal;

        private ProductListModel.ListItem selectedProduct;

        async Task OpenProductDetail(ProductListModel.ListItem item) => await OnProductDetailOpened.InvokeAsync(item);

        void DeleteProduct(ProductListModel.ListItem item)
        {
            selectedProduct = item;
            confirmDeleteModal.Show();
        }

        void RestoreProduct(ProductListModel.ListItem item)
        {
            selectedProduct = item;
            confirmRestoreModal.Show();
        }

        async Task ConfirmDeleteProduct()
        {
            try
            {
                await OnProductDeleteConfirmed.InvokeAsync(selectedProduct);
            }
            finally
            {
                selectedProduct = null;
            }
        }

        async Task ConfirmRestoreProduct()
        {
            try
            {
                await OnProductRestoreConfirmed.InvokeAsync(selectedProduct);
            }
            finally
            {
                selectedProduct = null;
            }
        }

        void CloseModal(Modal modal) => modal.Hide();
    }
}
