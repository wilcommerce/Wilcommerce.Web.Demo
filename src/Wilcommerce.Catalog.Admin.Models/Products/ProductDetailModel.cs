using System;
using Wilcommerce.Core.Common.Models;

namespace Wilcommerce.Catalog.Admin.Models.Products
{
    public class ProductDetailModel
    {
        public Guid Id { get; set; }

        public ProductInfoModel Details { get; set; }

        public SeoData Seo { get; set; }

        public ProductBrandModel Brand { get; set; }
    }
}
