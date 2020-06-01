using System;
using System.Collections.Generic;
using System.Text;

namespace Wilcommerce.Catalog.Admin.Models.Brands
{
    public class BrandListQueryModel
    {
        public bool ActiveOnly { get; set; }

        public int Page { get; set; }

        public int Size { get; set; }

        public string Query { get; set; }

        public BrandListQueryModel()
        {
            ActiveOnly = true;
            Page = 1;
            Size = 20;
        }
    }
}
