namespace Wilcommerce.Catalog.Admin.Models.CustomAttributes
{
    public class CustomAttributeListQueryModel
    {
        public bool ActiveOnly { get; set; }

        public int Page { get; set; }

        public int Size { get; set; }

        public string Query { get; set; }

        public CustomAttributeListQueryModel()
        {
            ActiveOnly = true;
            Page = 1;
            Size = 20;
        }
    }
}
