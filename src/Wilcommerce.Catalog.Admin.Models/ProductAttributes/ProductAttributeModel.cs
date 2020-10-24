using System;

namespace Wilcommerce.Catalog.Admin.Models.ProductAttributes
{
    public class ProductAttributeModel
    {
        public Guid Id { get; set; }

        public string Value { get; set; }

        public AttributeInfo Attribute { get; set; }

        public ProductAttributeModel()
        {
            Attribute = new AttributeInfo();
        }

        public class AttributeInfo
        {
            public Guid Id { get; set; }

            public string Name { get; set; }
        }
    }
}
