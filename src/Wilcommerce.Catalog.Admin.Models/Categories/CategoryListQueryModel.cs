namespace Wilcommerce.Catalog.Admin.Models.Categories
{
    public class CategoryListQueryModel
    {
        public bool ActiveOnly { get; set; }

        public int Page { get; set; }

        public int Size { get; set; }

        public string Query { get; set; }

        public bool VisibleOnly { get; set; }

        public CategoryListQueryModel()
        {
            ActiveOnly = true;
            VisibleOnly = true;
            Page = 1;
            Size = 20;
        }
    }
}
