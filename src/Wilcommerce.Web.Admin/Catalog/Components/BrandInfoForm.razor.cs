using Blazorise;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.Brands;

namespace Wilcommerce.Web.Admin.Catalog.Components
{
    public partial class BrandInfoForm
    {
        [Parameter]
        public BrandInfoModel Model { get; set; }

        [Parameter]
        public bool Readonly { get; set; }

        [Parameter]
        public EventCallback<BrandInfoModel> OnModelSaved { get; set; }

        EditContext context;

        bool editingEnabled;

        private BrandInfoModel _originalModel;

        string formControlClass => editingEnabled ? "form-control" : "form-control-plaintext";

        protected override Task OnInitializedAsync()
        {
            context = new EditContext(Model);
            editingEnabled = !Readonly;

            _originalModel = new BrandInfoModel
            {
                Description = Model.Description,
                Image = Model.Image,
                Name = Model.Name,
                Url = Model.Url
            };

            return base.OnInitializedAsync();
        }

        async Task HandleSubmit() => await OnModelSaved.InvokeAsync(Model);

        void Cancel()
        {
            Model = new BrandInfoModel
            {
                Description = _originalModel.Description,
                Image = _originalModel.Image,
                Name = _originalModel.Name,
                Url = _originalModel.Url
            };

            if (Readonly)
            {
                editingEnabled = false;
            }

            StateHasChanged();
        }

        void EnableEditing() => editingEnabled = true;

        async Task OnLogoChanged(FileChangedEventArgs e)
        {
            try
            {
                var file = e.Files.FirstOrDefault();
                if (file != null)
                {
                    var stream = new MemoryStream();
                    await file.WriteToStreamAsync(stream);

                    Model.Image = new FormFile(stream, 0, stream.Length, null, file.Name)
                    {
                        Headers = new HeaderDictionary(),
                        ContentType = file.Type
                    };
                }
            }
            finally
            {
                StateHasChanged();
            }
        }
    }
}
