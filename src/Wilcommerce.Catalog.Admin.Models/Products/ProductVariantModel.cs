using System;
using Wilcommerce.Core.Common.Models;

namespace Wilcommerce.Catalog.Admin.Models.Products
{
    public class ProductVariantModel
    {
        public Guid Id { get; set; }

        public string EanCode { get; set; }

        public string Sku { get; set; }

        public string Name { get; set; }

        public Currency Price { get; set; }
    }
}
