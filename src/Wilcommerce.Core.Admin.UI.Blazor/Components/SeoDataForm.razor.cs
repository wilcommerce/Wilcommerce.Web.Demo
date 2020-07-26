using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;
using Wilcommerce.Core.Common.Models;

namespace Wilcommerce.Core.Admin.UI.Blazor.Components
{
    public partial class SeoDataForm
    {
        [Parameter]
        public SeoData Model { get; set; }

        [Parameter]
        public bool Readonly { get; set; }

        [Parameter]
        public EventCallback<SeoData> OnModelSaved { get; set; }

        EditContext context;

        bool editingEnabled;

        string formControlClass => editingEnabled ? "form-control" : "form-control-plaintext";

        private SeoData _originalModel;

        protected override Task OnInitializedAsync()
        {
            context = new EditContext(Model);
            editingEnabled = !Readonly;

            _originalModel = new SeoData
            {
                Title = Model.Title,
                Description = Model.Description,
                Keywords = Model.Keywords
            };

            return base.OnInitializedAsync();
        }

        async Task HandleSubmit()
        {
            await OnModelSaved.InvokeAsync(Model);
        }

        void EnableEditing() => editingEnabled = true;

        void Cancel()
        {
            Model = new SeoData
            {
                Title = _originalModel.Title,
                Description = _originalModel.Description,
                Keywords = _originalModel.Keywords
            };

            if (Readonly)
            {
                editingEnabled = false;
            }

            StateHasChanged();
        }
    }
}
