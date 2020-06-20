using System;

namespace Wilcommerce.Catalog.Admin.Models.Categories
{
    public class CategoryListModel : ListModel<CategoryListModel.ListItem>
    {
        public class ListItem
        {
            public Guid Id { get; set; }

            public string Name { get; set; }

            public string Code { get; set; }

            public string Url { get; set; }

            public bool IsVisible { get; set; }

            public DateTime? VisibleFrom { get; set; }

            public DateTime? VisibleTo { get; set; }

            public bool Deleted { get; set; }
        }
    }
}
