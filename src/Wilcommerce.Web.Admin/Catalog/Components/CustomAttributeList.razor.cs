using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wilcommerce.Catalog.Admin.Models.CustomAttributes;

namespace Wilcommerce.Web.Admin.Catalog.Components
{
    public partial class CustomAttributeList
    {
        [Parameter]
        public CustomAttributeListModel Attributes { get; set; }

        [Parameter]
        public EventCallback<CustomAttributeListModel.ListItem> OnAttributeDetailOpened { get; set; }

        [Parameter]
        public EventCallback<CustomAttributeListModel.ListItem> OnAttributeDeleteConfirmed { get; set; }

        [Parameter]
        public EventCallback<CustomAttributeListModel.ListItem> OnAttributeRestoreConfirmed { get; set; }

        async Task OpenAttributeDetail(CustomAttributeListModel.ListItem attribute) => await OnAttributeDetailOpened.InvokeAsync(attribute);
    }
}
