using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.CustomAttributes;

namespace Wilcommerce.Catalog.Admin.UI.Blazor.Components.CustomAttributes
{
    public partial class CustomAttributeInfoForm
    {
        [Parameter]
        public CustomAttributeInfoModel Model { get; set; }

        [Parameter]
        public bool Readonly { get; set; }

        [Parameter]
        public EventCallback<CustomAttributeInfoModel> OnModelSaved { get; set; }

        EditContext context;

        bool editingEnabled;

        private CustomAttributeInfoModel _originalModel;

        string formControlClass => editingEnabled ? "form-control" : "form-control-plaintext";

        IEnumerable<string> dataTypes = Enum.GetNames(typeof(CustomAttributeInfoModel.DataTypes));

        IList<string> values = new List<string>();

        protected override Task OnInitializedAsync()
        {
            context = new EditContext(Model);
            editingEnabled = !Readonly;

            _originalModel = new CustomAttributeInfoModel
            {
                Description = Model.Description,
                Name = Model.Name,
                Type = Model.Type,
                UnitOfMeasure = Model.UnitOfMeasure,
                Values = Model.Values
            };

            values = Model.Values.Select(v => v.ToString()).ToList();

            return base.OnInitializedAsync();
        }

        async Task HandleSubmit()
        {
            Model.Values = values.Select(v => (object)v).ToList();
            await OnModelSaved.InvokeAsync(Model);
        }

        void Cancel()
        {
            Model = new CustomAttributeInfoModel
            {
                Description = _originalModel.Description,
                Name = _originalModel.Name,
                Type = _originalModel.Type,
                UnitOfMeasure = _originalModel.UnitOfMeasure,
                Values = _originalModel.Values
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
