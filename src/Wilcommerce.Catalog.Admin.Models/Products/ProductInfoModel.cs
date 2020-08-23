using System;
using Wilcommerce.Core.Common.Models;

namespace Wilcommerce.Catalog.Admin.Models.Products
{
    public class ProductInfoModel
    {
        public string EanCode { get; set; }

        public string Sku { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public Currency Price { get; set; }

        public string Description { get; set; }

        public int UnitInStock { get; set; }

        public bool IsOnSale { get; set; }

        public DateTime? OnSaleFrom { get; set; }

        public DateTime? OnSaleTo { get; set; }

        public ProductInfoModel()
        {
            Price = new Currency();
        }
    }
}
