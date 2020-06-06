using System;
using System.Collections.Generic;

namespace Wilcommerce.Catalog.Admin.Models.CustomAttributes
{
    public class CustomAttributeListModel
    {
        public int Total { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<ListItem> Items { get; set; }

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
