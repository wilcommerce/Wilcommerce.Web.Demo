using Blazorise;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Categories;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Components.Categories
{
    public partial class CategoryList
    {
        [Parameter]
        public CategoryListModel Categories { get; set; }

        [Parameter]
        public EventCallback<CategoryListModel.ListItem> OnCategoryDetailOpened { get; set; }

        [Parameter]
        public EventCallback<CategoryListModel.ListItem> OnCategoryDeleteConfirmed { get; set; }

        [Parameter]
        public EventCallback<CategoryListModel.ListItem> OnCategoryRestoreConfirmed { get; set; }

        private Modal confirmDeleteModal;

        private Modal confirmRestoreModal;

        private CategoryListModel.ListItem selectedCategory;

        async Task OpenCategoryDetail(CategoryListModel.ListItem item) => await OnCategoryDetailOpened.InvokeAsync(item);

        void DeleteCategory(CategoryListModel.ListItem item)
        {
            selectedCategory = item;
            confirmDeleteModal.Show();
        }

        void RestoreCategory(CategoryListModel.ListItem item)
        {
            selectedCategory = item;
            confirmRestoreModal.Show();
        }

        async Task ConfirmDeleteCategory()
        {
            try
            {
                await OnCategoryDeleteConfirmed.InvokeAsync(selectedCategory);
            }
            finally
            {
                selectedCategory = null;
            }
        }

        async Task ConfirmRestoreCategory()
        {
            try
            {
                await OnCategoryRestoreConfirmed.InvokeAsync(selectedCategory);
            }
            finally
            {
                selectedCategory = null;
            }
        }

        void CloseModal(Modal modal) => modal.Hide();
    }
}
