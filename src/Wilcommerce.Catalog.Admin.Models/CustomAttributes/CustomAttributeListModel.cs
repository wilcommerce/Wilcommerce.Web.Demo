using System;
using Wilcommerce.Core.Admin.Models;

namespace Wilcommerce.Catalog.Admin.Models.CustomAttributes
{
    public class CustomAttributeListModel : ListModel<CustomAttributeListModel.ListItem>
    {
        public class ListItem
        {
            public Guid Id { get; set; }

            public string Name { get; set; }

            public string DataType { get; set; }

            public string UnitOfMeasure { get; set; }

            public bool Deleted { get; set; }
        }
    }
}
