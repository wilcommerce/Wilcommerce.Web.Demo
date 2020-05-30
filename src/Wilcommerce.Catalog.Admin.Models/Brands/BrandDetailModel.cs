using System;
using Wilcommerce.Core.Common.Models;

namespace Wilcommerce.Catalog.Admin.Models.Brands
{
    public class BrandDetailModel
    {
        public Guid Id { get; set; }

        public BrandInfoModel Details { get; set; }

        public SeoData Seo { get; set; }
    }
}
