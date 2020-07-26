using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Categories;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Components.Categories
{
    public partial class CategoryInfoForm
    {
        [Parameter]
        public CategoryInfoModel Model { get; set; }

        [Parameter]
        public bool Readonly { get; set; }

        [Parameter]
        public EventCallback<CategoryInfoModel> OnModelSaved { get; set; }

        EditContext context;

        bool editingEnabled;

        private CategoryInfoModel _originalModel;

        string formControlClass => editingEnabled ? "form-control" : "form-control-plaintext";

        protected override Task OnInitializedAsync()
        {
            context = new EditContext(Model);
            editingEnabled = !Readonly;

            _originalModel = new CategoryInfoModel
            {
                Code = Model.Code,
                Description = Model.Description,
                IsVisible = Model.IsVisible,
                Name = Model.Name,
                Url = Model.Url,
                VisibleFrom = Model.VisibleFrom,
                VisibleTo = Model.VisibleTo
            };

            return base.OnInitializedAsync();
        }

        async Task HandleSubmit() => await OnModelSaved.InvokeAsync(Model);

        void Cancel()
        {
            Model = new CategoryInfoModel
            {
                Code = _originalModel.Code,
                Description = _originalModel.Description,
                IsVisible = _originalModel.IsVisible,
                Name = _originalModel.Name,
                Url = _originalModel.Url,
                VisibleFrom = _originalModel.VisibleFrom,
                VisibleTo = _originalModel.VisibleTo
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
