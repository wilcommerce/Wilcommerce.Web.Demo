using System;

namespace Wilcommerce.Catalog.Admin.Models.ProductAttributes
{
    public class ProductAttributeListModel
    {
        public Guid Id { get; set; }

        public Guid AttributeId { get; set; }

        public string AttributeName { get; set; }

        public object Value { get; set; }
    }
}
