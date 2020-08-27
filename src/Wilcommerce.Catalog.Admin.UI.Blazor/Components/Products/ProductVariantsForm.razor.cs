using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Products;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Components.Products
{
    public partial class ProductVariantsForm
    {
        [Parameter]
        public bool Readonly { get; set; }

        [Parameter]
        public IList<ProductVariantModel> Variants { get; set; }

        [Parameter]
        public EventCallback<ProductVariantModel> OnVariantSaved { get; set; }

        [Parameter]
        public EventCallback<ProductVariantModel> OnVariantRemoved { get; set; }

        EditContext context;

        bool editingEnabled;

        ProductVariantModel model;

        string formControlClass => editingEnabled ? "form-control" : "form-control-plaintext";

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            model = new ProductVariantModel();
            context = new EditContext(model);

            editingEnabled = !Readonly;
        }

        void AddNewVariant()
        {
            model = new ProductVariantModel();
            editingEnabled = true;
        }

        void EditVariant(ProductVariantModel variant)
        {
            model = variant;
            editingEnabled = true;
        }

        async Task SaveVariant() => await OnVariantSaved.InvokeAsync(model);

        async Task RemoveVariant(ProductVariantModel variant) => await OnVariantRemoved.InvokeAsync(variant);

        void Cancel()
        {
            model = new ProductVariantModel();
            editingEnabled = false;
        }
    }
}
