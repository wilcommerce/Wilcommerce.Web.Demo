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
        [Inject]
        public NavigationManager Navigation { get; set; }

        [Parameter]
        public CustomAttributeListModel Attributes { get; set; }
    }
}
