namespace Wilcommerce.Catalog.Admin.Models.Products
{
    public class ProductListQueryModel
    {
        public bool ActiveOnly { get; set; }

        public int Page { get; set; }

        public int Size { get; set; }

        public string Query { get; set; }

        public bool AvailableOnly { get; set; }

        public ProductListQueryModel()
        {
            ActiveOnly = true;
            AvailableOnly = false;
            Page = 1;
            Size = 20;
        }
    }
}
