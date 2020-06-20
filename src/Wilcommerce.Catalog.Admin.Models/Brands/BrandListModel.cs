using System;

namespace Wilcommerce.Catalog.Admin.Models.Brands
{
    public class BrandListModel : ListModel<BrandListModel.ListItem>
    {
        public class ListItem
        {
            public Guid Id { get; set; }

            public string Name { get; set; }

            public string Url { get; set; }

            public string Description { get; set; }

            public bool Deleted { get; set; }
        }
    }
}
