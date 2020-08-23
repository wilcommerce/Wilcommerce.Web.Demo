using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Products;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Components.Products
{
    public partial class ProductInfoForm
    {
        [Parameter]
        public ProductInfoModel Model { get; set; }

        [Parameter]
        public bool Readonly { get; set; }

        [Parameter]
        public EventCallback<ProductInfoModel> OnModelSaved { get; set; }

        EditContext context;

        bool editingEnabled;

        private ProductInfoModel _originalModel;

        string formControlClass => editingEnabled ? "form-control" : "form-control-plaintext";

        protected override Task OnInitializedAsync()
        {
            context = new EditContext(Model);
            editingEnabled = !Readonly;

            _originalModel = new ProductInfoModel
            {
                Description = Model.Description,
                EanCode = Model.EanCode,
                IsOnSale = Model.IsOnSale,
                Name = Model.Name,
                OnSaleFrom = Model.OnSaleFrom,
                OnSaleTo = Model.OnSaleTo,
                Price = Model.Price,
                Sku = Model.Sku,
                UnitInStock = Model.UnitInStock,
                Url = Model.Url
            };

            return base.OnInitializedAsync();
        }

        async Task HandleSubmit() => await OnModelSaved.InvokeAsync(Model);

        void Cancel()
        {
            Model = new ProductInfoModel
            {
                Description = _originalModel.Description,
                EanCode = _originalModel.EanCode,
                IsOnSale = _originalModel.IsOnSale,
                Name = _originalModel.Name,
                OnSaleFrom = _originalModel.OnSaleFrom,
                OnSaleTo = _originalModel.OnSaleTo,
                Price = _originalModel.Price,
                Sku = _originalModel.Sku,
                UnitInStock = _originalModel.UnitInStock,
                Url = _originalModel.Url
            };

            if (Readonly)
            {
                editingEnabled = false;
            }

            StateHasChanged();
        }

        void EnableEditing() => editingEnabled = true;
    }
}
