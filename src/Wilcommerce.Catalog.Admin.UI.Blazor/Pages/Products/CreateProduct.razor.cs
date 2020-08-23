using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Products;
using Wilcommerce.Catalog.Admin.UI.Blazor.Services.Http;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Pages.Products
{
    public partial class CreateProduct
    {
        [Inject]
        public ProductsHttpClient Client { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        private ProductInfoModel model = new ProductInfoModel();

        private bool errorRaised = false;

        async Task CreateNewProduct(ProductInfoModel newProduct)
        {
            try
            {
                await Client.CreateProduct(newProduct);
                Navigation.NavigateTo("catalog/products");
            }
            catch 
            {
                errorRaised = true;
            }
        }
    }
}
