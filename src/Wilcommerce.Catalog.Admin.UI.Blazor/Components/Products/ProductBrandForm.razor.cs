using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Products;
using Wilcommerce.Catalog.Admin.UI.Blazor.Services.Http;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Components.Products
{
    public partial class ProductBrandForm
    {
        [Inject]
        public BrandsHttpClient BrandsClient { get; set; }

        [Parameter]
        public ProductBrandModel Brand { get; set; }

        [Parameter]
        public EventCallback<ProductBrandModel> OnModelSaved { get; set; }

        [Parameter]
        public bool Readonly { get; set; }

        EditContext context;

        bool editingEnabled;

        string formControlClass => editingEnabled ? "form-control" : "form-control-plaintext";

        IEnumerable<ProductBrandModel> brands = new ProductBrandModel[0];

        private ProductBrandModel _originalModel;

        private Func<ProductBrandModel, string> displayValue = brand => brand.BrandId == Guid.Empty ? "Choose a brand" : brand.Name;

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            context = new EditContext(Brand);

            editingEnabled = !Readonly;
            _originalModel = new ProductBrandModel
            {
                BrandId = Brand.BrandId,
                Name = Brand.Name
            };
        }

        async Task<IEnumerable<ProductBrandModel>> SearchBrandsByText(string query)
        {
            var brandsFromApi = await BrandsClient.SearchBrandsByText(query);
            brands = brandsFromApi.Select(b => new ProductBrandModel
            {
                BrandId = b.Id,
                Name = b.Name
            }).ToArray();

            return brands;
        }

        async Task HandleSubmit() => await OnModelSaved.InvokeAsync(Brand);

        void EnableEditing() => editingEnabled = true;

        void Cancel()
        {
            Brand = new ProductBrandModel
            {
                BrandId = _originalModel.BrandId,
                Name = _originalModel.Name
            };

            editingEnabled = false;
        }
    }
}
