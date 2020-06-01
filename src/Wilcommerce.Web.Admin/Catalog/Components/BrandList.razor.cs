using Microsoft.AspNetCore.Components;
using Wilcommerce.Catalog.Admin.Models.Brands;

namespace Wilcommerce.Web.Admin.Catalog.Components
{
    public partial class BrandList
    {
        [Inject]
        public NavigationManager Navigation { get; set; }

        [Parameter]
        public BrandListModel Brands { get; set; }

        private BrandListQueryModel queryModel = new BrandListQueryModel();

        void OpenBrandDetail(BrandListModel.ListItem item)
        {
            var url = $"catalog/brands/{item.Id}";
            Navigation.NavigateTo(url);
        }
    }
}
