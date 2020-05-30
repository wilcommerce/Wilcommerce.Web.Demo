using System;
using System.Collections.Generic;

namespace Wilcommerce.Catalog.Admin.Models.Brands
{
    public class BrandListModel
    {
        public int Total { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<ListItem> Items { get; set; }

        public class ListItem
        {
            public Guid Id { get; set; }

            public string Name { get; set; }

            public string Url { get; set; }

            public string Description { get; set; }
        }
    }
}
