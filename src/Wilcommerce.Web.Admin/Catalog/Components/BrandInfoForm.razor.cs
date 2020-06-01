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
        public EventCallback<BrandInfoModel> OnModelSaved { get; set; }

        EditContext context;

        protected override Task OnInitializedAsync()
        {
            context = new EditContext(Model);
            return base.OnInitializedAsync();
        }

        async Task HandleSubmit()
        {
            await OnModelSaved.InvokeAsync(Model);
        }

        async Task OnLogoChanged(FileChangedEventArgs e)
        {
            try
            {
                var file = e.Files.FirstOrDefault();
                if (file != null)
                {
                    using var stream = new MemoryStream();
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
