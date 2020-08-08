using System;
using Wilcommerce.Core.Admin.Models;
using Wilcommerce.Core.Common.Models;

namespace Wilcommerce.Catalog.Admin.Models.Products
{
    public class ProductListModel : ListModel<ProductListModel.ListItem>
    {
        public class ListItem
        {
            public Guid Id { get; set; }

            public string EanCode { get; set; }

            public string Sku { get; set; }

            public string Name { get; set; }

            public bool Deleted { get; set; }

            public Currency Price { get; set; }

            public bool IsOnSale { get; set; }

            public DateTime? OnSaleFrom { get; set; }

            public DateTime? OnSaleTo { get; set; }

            public int UnitInStock { get; set; }
        }
    }
}
