using System;
using Wilcommerce.Catalog.Admin.Models.CustomAttributes;

namespace Wilcommerce.Catalog.Admin.Models.ProductAttributes
{
    public class ProductAttributeModel
    {
        public Guid Id { get; set; }

        public string Value { get; set; }

        public CustomAttributeDescriptorModel Attribute { get; set; }

        public ProductAttributeModel()
        {
            Attribute = new CustomAttributeDescriptorModel();
        }
    }
}
